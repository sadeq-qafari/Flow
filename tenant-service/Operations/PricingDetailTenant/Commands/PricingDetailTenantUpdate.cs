using System.Threading.Tasks;
using Meteor.Operation.Db;
using Tenant.Operations.PricingDetailTenant.Dtos;

namespace Tenant.Operations.PricingDetailTenant.Commands
{
    public class PricingDetailTenantUpdate : DbOperationAsync<PricingDetailTenantUpdateInDto, bool>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(sql => sql.Update("[Tenant].[PricingDetailTenant]",
                 @"[PricingItemId]=@PricingItemId,
							[PricingTenantId]=@PricingTenantId,
							[Cost]=@Cost,
							[Percent]=@Percent,
							[FromPrice]=@FromPrice,
							[ToPrice]=@ToPrice,
							[ModifiedAt]=GETDATE(),
                    		[ModifiedBy]=@ModifiedBy,
							[TenantId]=@TenantId").WhereThisId()).ExecuteAsync() > 0;
        }
    }
}
