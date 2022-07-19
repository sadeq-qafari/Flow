using Core.Meteor;
using Flow.Operations.Lookup.Dtos;
using Meteor.Database.SqlDialect;

namespace Flow.Operations.Lookup.Queries
{
    public class GetLookupPage : DbQueryPage<LookupDto>
    {
        public GetLookupPage() : base("[Flow].[Lookup]")
        {
        }

        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            Parameters.Add("TypeLookupMP", SqServices.GetModelProperty("Flow","Lookup","typeLookup")!.Id);
            return SqlFactory!.Create().Select("[Flow].[Lookup] Lookup", isForCount ? "COUNT(*)" : @"
						Lookup.*, 
						TypeLookup.Title AS TypeLookupTitle")
                .LeftJoin("[Core].[ModelPropertyLookup] TypeLookup",  "Lookup.TypeLookup = TypeLookup.Value AND TypeLookup.ModelPropertyId=@TypeLookupMP  AND  TypeLookup.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[Lookup].[{fieldName}]";
    }
}
