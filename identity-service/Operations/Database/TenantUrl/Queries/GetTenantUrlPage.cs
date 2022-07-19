using System.Collections.Generic;
using System.Linq;
using Identity.Operations.Database.TenantUrl.Dtos;
using Meteor.Database.SqlDialect;
using Core.Meteor;
using Core.Meteor.Dto;

namespace Identity.Operations.Database.TenantUrl.Queries
{
    public class GetTenantUrlPage : DbQueryPage<TenantUrlDto>
    {
        public GetTenantUrlPage() : base("[Identity].[TenantUrl]")
        {
        }

        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            Parameters.Add("TypeLookup", SqServices.GetModelProperty("Identity","TenantUrl","typeLookup")!.Id);
            return SqlFactory!.Create().Select("[Identity].[TenantUrl] TenantUrl", isForCount ? "COUNT(*)" : @"
						TenantUrl.*, 
						TypeLookup.Title AS TypeLookupTitle,
                        Tenant.Title AS TenantTitle")
                .LeftJoin("[Core].[ModelPropertyLookup] TypeLookup",  "TenantUrl.TypeLookup = TypeLookup.Value AND TypeLookup.ModelPropertyId=@TypeLookup  AND  TypeLookup.IsDeleted=0")
                .LeftJoin("[Identity].[Tenant] Tenant",  "Tenant.Id = TenantUrl.TenantId AND Tenant.IsDeleted=0");
        }

        protected override void BuildWhere(SqlWhereBuilder builder, List<FilterItem> filterItems)
        {
            builder.Where($"[TenantUrl].IsDeleted=0 {(Input.TenantId != 1 ? "AND [TenantUrl].TenantId=@TenantId" : "")}");
            if (!filterItems.Any())
                return;
            foreach (var filterItem in filterItems.Where(x => x.IsValid()))
                builder.And(filterItem.GetWhereSql(GetFieldName(filterItem.FieldName)));
        }

        protected override string GetFieldName(string fieldName) =>
            $"[TenantUrl].[{fieldName}]";
    }
}
