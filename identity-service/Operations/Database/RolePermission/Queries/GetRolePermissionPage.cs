using Identity.Operations.Database.RolePermission.Dtos;
using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.RolePermission.Queries
{
    public class GetRolePermissionPage : SaanaaDbQueryPage<RolePermissionDto>
    {
        public GetRolePermissionPage() : base("[Identity].[RolePermission]")
        {
        }



        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {

            return SqlFactory!.Create().Select("[Identity].[RolePermission] RolePermission", isForCount ? "COUNT(*)" : @"
						RolePermission.*, 
						Role.Title AS RoleTitle,
						Permission.Title AS PermissionTitle")
                .LeftJoin("[Identity].[Role] Role",  "RolePermission.RoleId = Role.Id  AND  Role.IsDeleted=0")
                .LeftJoin("[Identity].[Permission] Permission",  "RolePermission.PermissionId = Permission.Id  AND  Permission.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[RolePermission].[{fieldName}]";
    }
}
