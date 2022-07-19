using Meteor.Database.SqlDialect;
using Core.Meteor;
using Tenant.Operations.Pricing.Dtos;

namespace Tenant.Operations.Pricing.Queries
{
    public class GetPricingPage : DbQueryPage<PricingDto>
    {
        public GetPricingPage() : base("[Tenant].[Pricing]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            
            return SqlFactory!.Create().Select("[Tenant].[Pricing] Pricing", isForCount ? "COUNT(*)" : @"
						Pricing.*, 
						Application.Title AS ApplicationTitle")
                .LeftJoin("[Core].[Application] Application",  "Pricing.ApplicationId = Application.Id  AND  Application.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[Pricing].[{fieldName}]";
    }
}