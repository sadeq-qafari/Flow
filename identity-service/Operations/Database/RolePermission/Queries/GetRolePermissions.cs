using System.Threading.Tasks;
using Identity.Operations.Database.RolePermission.Dtos;
using Meteor.Operation.Db;
using Meteor.Utils;
using Core.Meteor.Dto;

namespace Identity.Operations.Database.RolePermission.Queries
{
    public class GetRolePermissions : DbOperationAsync<DbSelectInDto, PermissionCheckList>
    {
        protected override async Task ExecutionAsync()
        {
            var rolePermissions = await NewSql(@"EXECUTE [Identity].sp_RolePermissions @Id = @Id")
                .QueryAsync<string>();
            if (rolePermissions == null)
                throw Errors.DatabaseError("no_permissions");

            var permissions = await NewSql(sql => sql
                    .Select("[Identity].[Permission] Permission", "Name")
                    .Where("Permission.IsDeleted=0"))
                .QueryAsync<string>();

            Output = new PermissionCheckList(permissions, rolePermissions);
        }
    }
}
