using System.Linq;
using System.Threading.Tasks;
using Meteor.Operation.Db;
using Meteor.Utils;

namespace Tenant.Operations.OrganizationDetail.Queries
{
    public class GetOrganizationDetail : DbOperationAsync<int,object>
    {
        protected override async Task ExecutionAsync()
        {
            var organizationPropertyNames = await NewSql(sql =>
                    sql.Select("[Identity].[Tenant] Tenant", "ModelProperty.Name")
                        .InnerJoin("[Core].[Application]","Tenant.ApplicationId = Application.Id")
                        .InnerJoin("[Core].[Model] Model","Model.Name = N'Organization'+Application.Name")
                        .InnerJoin("[Core].[ModelProperty] ModelProperty","ModelProperty.ModelId=Model.Id And ModelProperty.IsDeleted=0")
                        .Where("Tenant.Id = @TenantId"), new { TenantId = Input })
                .QueryAsync<string>() ?? throw Errors.NotFound("requested_organization_not_found");
            organizationPropertyNames = organizationPropertyNames.ToList();
            Output = await NewSql($@"
            WITH pivot_data AS
            (
                SELECT 
                Name,
                Value 
                FROM Tenant.OrganizationDetail WHERE IsDeleted = 0 AND TenantId = @TenantId
            )
            SELECT {string.Join(',', organizationPropertyNames.Select(i => $"[{i}]"))}
            FROM pivot_data
            PIVOT (max(value) FOR Name IN ({string.Join(',', organizationPropertyNames.Select(i => $"[{i}]"))} )) AS p;
            ", new { TenantId = Input }).QueryFirstOrDefaultAsync<object>();
        }
    }
}
