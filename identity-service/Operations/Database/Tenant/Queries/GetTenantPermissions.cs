using System.Threading.Tasks;
using Core.AspNetCore.Operations.Db.Identity.Dto;
using Meteor.Operation.Db;
using Meteor.Utils;
using Core.Meteor.Dto;

namespace Identity.Operations.Database.Tenant.Queries
{
    public class GetTenantPermissions : DbOperationAsync<DbSelectInDto,PermissionStore>
    {
        protected override async Task ExecutionAsync()
        {
            var items = await NewSql("EXECUTE [Identity].sp_TenantPermissions @TenantId = @TenantId")
                .QueryAsync<string>()
                .ToListAsync();
            if (items == null)
                throw Errors.DatabaseError("no_permissions");

            Output = new PermissionStore(items);
        }
    }
}
