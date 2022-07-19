using System.Threading.Tasks;
using Core.AspNetCore.Operations.Db.Identity.Dto;
using Meteor.Operation.Db;
using Meteor.Utils;

namespace Identity.Operations.Database.User.Queries
{
    public class GetUserPermissions : DbOperationAsync<Dtos.GetUserPermissionsInDto, PermissionStore>
    {
        protected override async Task ExecutionAsync()
        {
            var items = await NewSql(@"EXECUTE [Identity].sp_UserPermissions @UserId = @UserId 
                                     ,@TenantId = @TenantId 
                                     ,@BranchId = @BranchId",
                    new
                    {
                        UserId = Input.ActionBy,
                        Input.TenantId,
                        Input.BranchId
                    })
                .QueryAsync<string>();
            if (items == null)
                throw Errors.DatabaseError("no_permissions");

            Output = new PermissionStore(items);
        }
    }
}
