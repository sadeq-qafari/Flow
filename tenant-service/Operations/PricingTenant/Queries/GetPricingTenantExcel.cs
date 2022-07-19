using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Tenant.Operations.PricingTenant.Dtos;

namespace Tenant.Operations.PricingTenant.Queries
{
    public class GetPricingTenantExcel : DbQueryExcel<PricingTenantDto>
    {
        public GetPricingTenantExcel() : base("[Tenant].[PricingTenant]")
        {
        }
        
        protected override async Task<List<PricingTenantDto>?> GetItems() =>
            (await OperationFactory!.New<GetPricingTenantPage>().ExecuteAsync(Input))?.Items;
    }
}