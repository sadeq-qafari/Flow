using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Meteor.Operation.Db;
using Tenant.Operations.Organization.Dto;

namespace Tenant.Operations.Organization.Queries
{
    public class GetOrganizationInfo : DbOperationAsync<GetOrganizationInfoInDto, OrganizationInfoDto>
    {
        protected override async Task ExecutionAsync()
        {
            var grid = await NewSql("EXECUTE Tenant.sp_OrganizationInfo @Id = @TenantId")
                .QueryMultipleAsync();
            Output = await grid.ReadFirstAsync<OrganizationInfoDto>();
            Output.Details = (await grid.ReadAsync<OrganizationDetailItem>())?
                .ToDictionary(row => row.Name.Camelize(), row => row.Value);
        }
    }
}
