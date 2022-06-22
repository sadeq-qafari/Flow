using System;
using System.Threading.Tasks;
using Meteor.Utils;
using Saanaa.Core.AspNetCore.Redis;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.UserRole.Commands
{
    public class UserRoleRemove : SaanaaDbDeleteAsync
    {
        public UserRoleRemove() : base("[Identity].[UserRole]")
        {
        }

        protected override async Task OnSuccessAsync()
        {
            var userId = await NewSql(sql => sql.Select("[Identity].[UserRole]", "UserId")
                .Where("Id = @Id")).ExecuteScalarAsync<int>();
            var redis = OperationFactory?.GetService<RedisCache>()
                        ?? throw Errors.InvalidOperation("redis_is_not_registered");
            var userPermissionRedisKeys = await NewSql(sql => sql.Select("[Identity].[TenantUser]",
                        @"'base:user:prm:'+
                                    CAST(TenantUser.TenantId AS NVARCHAR)+':'+
                                    CAST(TenantUser.BranchId AS NVARCHAR)+':'+
                                    CAST(TenantUser.UserId AS NVARCHAR)")
                    .Where("TenantUser.UserId=@UserId AND TenantUser.IsDeleted=0"), new {UserId = userId}
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
