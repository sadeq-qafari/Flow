using System.Collections.Generic;
using System.Linq;
using Meteor.Database.SqlDialect;
using Core.Meteor;
using Core.Meteor.Dto;
using Tenant.Operations.PricingDetailTenant.Dtos;

namespace Tenant.Operations.PricingDetailTenant.Queries
{
    public class GetPricingDetailTenantPage : DbQueryPage<PricingDetailTenantDto>
    {
        public GetPricingDetailTenantPage() : base("[Tenant].[PricingDetailTenant]")
        {
        }


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            return SqlFactory!.Create().Select("[Tenant].[PricingDetailTenant] PricingDetailTenant", isForCount
                    ? "COUNT(*)"
                    : @"
						PricingDetailTenant.*, 
                        Tenant.Title AS TenantTitle, 
						PricingItem.Title AS PricingItemTitle")
                .LeftJoin("[Tenant].[PricingItem] PricingItem",
                    "PricingDetailTenant.PricingItemId = PricingItem.Id  AND  PricingItem.IsDeleted=0")
                .LeftJoin("[Identity].[Tenant] Tenant", "PricingDetailTenant.TenantId = Tenant.Id  AND  Tenant.IsDeleted=0");
        }

        protected override void BuildWhere(SqlWhereBuilder builder, List<FilterItem> filterItems)
        {
            builder.Where($"[PricingDetailTenant].IsDeleted=0 {(Input.TenantId != 1 ? "AND [PricingDetailTenant].TenantId=@TenantId" : "")}");
            if (!filterItems.Any())
                return;
            foreach (var filterItem in filterItems.Where(x => x.IsValid()))
                builder.And(filterItem.GetWhereSql(GetFieldName(filterItem.FieldName)));
        }


        protected override string GetFieldName(string fieldName) =>
            $"[PricingDetailTenant].[{fieldName}]";
    }
}
