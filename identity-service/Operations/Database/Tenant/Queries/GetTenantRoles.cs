using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.Operation.Db;
using Core.Meteor.Dto;

namespace Identity.Operations.Database.Tenant.Queries
{
    public class GetTenantRoles : DbOperationAsync<DbSelectInDto, IEnumerable<int>>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql("EXECUTE [Identity].sp_TenantRoles @TenantId = @TenantId")
                .QueryAsync<int>();
        }
    }
}
