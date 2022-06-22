using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;
using Tenant.Operations.PricingLog.Dtos;

namespace Tenant.Operations.PricingLog.Queries
{
    public class GetPricingLogPage : SaanaaDbQueryPage<PricingLogDto>
    {
        public GetPricingLogPage() : base("[Tenant].[PricingLog]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            
            return SqlFactory!.Create().Select("[Tenant].[PricingLog] PricingLog", isForCount ? "COUNT(*)" : @"
						PricingLog.*, 
						PricingItem.Title AS PricingItemTitle")
                .LeftJoin("[Tenant].[PricingItem] PricingItem",  "PricingLog.PricingItemId = PricingItem.Id  AND  PricingItem.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[PricingLog].[{fieldName}]";
    }
}