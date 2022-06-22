using System;
using System.Linq;
using System.Threading.Tasks;
using Identity.Operations.Database.RolePermission.Dtos;
using Meteor.Operation.Db;
using Meteor.Utils;
using Saanaa.Core.AspNetCore.Redis;

namespace Identity.Operations.Database.RolePermission.Commands
{
    public class RolePermissionMerge : DbOperationAsync<RolePermissionMergeInDto, bool>
    {
        protected override async Task ExecutionAsync()
        {
            var permissions = (
                from x in Input.PermissionCheckList
                from y in x.Value
                from z in y.Value
                where z.Value
                select $"{x.Key}.{y.Key}.{z.Key}").ToList();
            const string sqlText = @"
MERGE [Identity].RolePermission AS Target
    USING (SELECT
        *
      FROM [Identity].Permission
      WHERE LOWER(Name) IN @Permissions) AS Source
    ON Target.PermissionId = Source.Id
      AND RoleId = @RoleId
    WHEN MATCHED AND TARGET.IsDeleted = 1 
        THEN UPDATE SET IsDeleted = 0
           ,ModifiedBy = @ActionBy
           ,ModifiedAt = GETDATE()
    WHEN NOT MATCHED BY TARGET
      THEN INSERT
        (
          RoleId
         ,PermissionId
         ,IsActive
         ,IsDeleted
         ,CreatedBy
         ,CreatedAt
         ,TenantId
        )
        VALUES
          (
            @RoleId, Source.Id, 1, 0, @ActionBy, GETDATE(), 0
          )
    WHEN NOT MATCHED BY SOURCE
      AND RoleId = @RoleId
      THEN UPDATE
        SET IsDeleted = 1
           ,ModifiedBy = @ActionBy
           ,ModifiedAt = GETDATE();";
            Output = await NewSql(sqlText,
                    new {Input.ActionBy, Input.RoleId, Permissions = permissions})
                .ExecuteAsync()
                .ValidateDatabaseAffectedRows() > 0;
        }

        protected override async Task OnSuccessAsync()
        {
            var redis = OperationFactory?.GetService<RedisCache>()
                        ?? throw Errors.InvalidOperation("redis_is_not_registered");
            var userPermissionRedisKeys = await NewSql(sql => sql.Select("[Identity].[UserRole]",
                    @"'base:user:prm:'
                                + CAST(TenantUser.TenantId AS NVARCHAR) + ':'
                                + CAST(TenantUser.BranchId AS NVARCHAR) + ':'
                                + CAST(TenantUser.UserId AS NVARCHAR)")
                .InnerJoin("[Identity].TenantUser TenantUser", "TenantUser.UserId = UserRole.UserId AND TenantUser.IsDeleted = 0")
                .Where("UserRole.RoleId=@RoleId AND UserRole.IsDeleted=0"), new {Input.RoleId}
            ).QueryAsync<string>();
            foreach (var key in userPermissionRedisKeys)
            {
                try
                {
                    redis.Db.KeyDelete(key);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
