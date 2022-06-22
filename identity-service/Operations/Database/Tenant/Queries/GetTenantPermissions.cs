using System.Threading.Tasks;
using Meteor.Operation.Db;
using Meteor.Utils;
using Saanaa.Core.AspNetCore.Operations.Db.UserPermissions.Dto;
using Saanaa.Core.Meteor.Dto;

namespace Identity.Operations.Database.Tenant.Queries
{
    public class GetTenantPermissions : DbOperationAsync<SaanaaDbSelectInDto,PermissionStore>
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
