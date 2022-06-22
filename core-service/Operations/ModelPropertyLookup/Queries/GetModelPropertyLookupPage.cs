using Core.Operations.ModelPropertyLookup.Dto;
using Humanizer;
using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;

namespace Core.Operations.ModelPropertyLookup.Queries
{
    public class GetModelPropertyLookupPage : SaanaaDbQueryPage<ModelPropertyLookupDto>
    {
        public GetModelPropertyLookupPage() : base("[Core].[ModelPropertyLookup]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            return SqlFactory!.Create().Select("[Core].[ModelPropertyLookup] ModelPropertyLookup", isForCount ? "COUNT(*)" : "ModelPropertyLookup.*, ModelProperty1.Title AS ModelPropertyTitle")
                .LeftJoin("[Core].[ModelProperty] ModelProperty1", "ModelPropertyLookup.ModelPropertyId=ModelProperty1.Id AND ModelProperty1.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName)
        {
            return fieldName.Pascalize() switch
            {
                "ModelPropertyTitle" => "ModelProperty1.Title",
                _ => $"[ModelPropertyLookup].[{fieldName}]"
            };
        }
    }
}
