using Flow.Operations.LookupItem.Dtos;
using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;

namespace Flow.Operations.LookupItem.Queries
{
    public class GetLookupItemPage : SaanaaDbQueryPage<LookupItemDto>
    {
        public GetLookupItemPage() : base("[Flow].[LookupItem]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            
            return SqlFactory!.Create().Select("[Flow].[LookupItem] LookupItem", isForCount ? "COUNT(*)" : @"
						LookupItem.*, 
						Lookup.Title AS LookupTitle")
                .LeftJoin("[Flow].[Lookup] Lookup",  "LookupItem.LookupId = Lookup.Id  AND  Lookup.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[LookupItem].[{fieldName}]";
    }
}