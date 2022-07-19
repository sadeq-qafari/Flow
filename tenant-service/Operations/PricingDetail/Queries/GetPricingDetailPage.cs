using Meteor.Database.SqlDialect;
using Core.Meteor;
using Tenant.Operations.PricingDetail.Dtos;

namespace Tenant.Operations.PricingDetail.Queries
{
    public class GetPricingDetailPage : DbQueryPage<PricingDetailDto>
    {
        public GetPricingDetailPage() : base("[Tenant].[PricingDetail]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            Parameters.Add("TypeLookup", SqServices.GetModelProperty("Tenant","PricingDetail","typeLookup")!.Id);
            return SqlFactory!.Create().Select("[Tenant].[PricingDetail] PricingDetail", isForCount ? "COUNT(*)" : @"
						PricingDetail.*, 
						Pricing.Title AS PricingTitle,
						PricingItem.Title AS PricingItemTitle,
						TypeLookup.Title AS TypeLookupTitle")
                .LeftJoin("[Tenant].[Pricing] Pricing",  "PricingDetail.PricingId = Pricing.Id  AND  Pricing.IsDeleted=0")
                .LeftJoin("[Tenant].[PricingDetail] PricingItem",  "PricingDetail.PricingItemId = PricingItem.Id  AND  PricingItem.IsDeleted=0")
                .LeftJoin("[Core].[ModelPropertyLookup] TypeLookup",  "PricingDetail.TypeLookup = TypeLookup.Value AND TypeLookup.ModelPropertyId=@TypeLookup  AND  TypeLookup.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[PricingDetail].[{fieldName}]";
    }
}