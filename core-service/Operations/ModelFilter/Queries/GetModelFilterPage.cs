using Core.Meteor;
using Core.Operations.ModelFilter.Dtos;
using Meteor.Database.SqlDialect;

namespace Core.Operations.ModelFilter.Queries
{
    public class GetModelFilterPage : DbQueryPage<ModelFilterDto>
    {
        public GetModelFilterPage() : base("[Core].[ModelFilter]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            Parameters.Add("TypeLookup", SqServices.GetModelProperty("Core","ModelFilter","typeLookup")!.Id);
            return SqlFactory!.Create().Select("[Core].[ModelFilter] ModelFilter", isForCount ? "COUNT(*)" : @"
						ModelFilter.*, 
						Model.Title AS ModelTitle,
						TypeLookup.Title AS TypeLookupTitle")
                .LeftJoin("[Core].[Model] Model",  "ModelFilter.ModelId = Model.Id  AND  Model.IsDeleted=0")
                .LeftJoin("[Core].[ModelPropertyLookup] TypeLookup",  "ModelFilter.TypeLookup = TypeLookup.Value AND TypeLookup.ModelPropertyId=@TypeLookup  AND  TypeLookup.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[ModelFilter].[{fieldName}]";
    }
}