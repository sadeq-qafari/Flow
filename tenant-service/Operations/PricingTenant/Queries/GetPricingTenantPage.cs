using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;
using Tenant.Operations.PricingTenant.Dtos;

namespace Tenant.Operations.PricingTenant.Queries
{
    public class GetPricingTenantPage : SaanaaDbQueryPage<PricingTenantDto>
    {
        public GetPricingTenantPage() : base("[Tenant].[PricingTenant]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            
            return SqlFactory!.Create().Select("[Tenant].[PricingTenant] PricingTenant", isForCount ? "COUNT(*)" : @"
						PricingTenant.*, 
						Pricing.Title AS PricingTitle")
                .LeftJoin("[Tenant].[Pricing] Pricing",  "PricingTenant.PricingId = Pricing.Id  AND  Pricing.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[PricingTenant].[{fieldName}]";
    }
}