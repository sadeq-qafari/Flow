using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.Operation.Db;
using Tenant.Operations.Organization.Dto;

namespace Tenant.Operations.Organization.Queries
{
    public class GetOrganizationIncompleteInformation : DbOperationAsync<int, IEnumerable<OrganizationIncompleteInformationDto?>?>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(@"EXECUTE Tenant.sp_IncompleteInformation @TenantId = @TenantId",
                new { TenantId = Input }).QueryAsync<OrganizationIncompleteInformationDto>();
        }
    }
}