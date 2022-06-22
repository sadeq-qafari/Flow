using Flow.Operations.FormAction.Dtos;
using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;

namespace Flow.Operations.FormAction.Queries
{
    public class GetFormActionPage : SaanaaDbQueryPage<FormActionDto>
    {
        public GetFormActionPage() : base("[Flow].[FormAction]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            Parameters.Add("TypeLookup", SaanaaServices.GetModelProperty("Flow","FormAction","typeLookup")!.Id);
            return SqlFactory!.Create().Select("[Flow].[FormAction] FormAction", isForCount ? "COUNT(*)" : @"
						FormAction.*, 
						Form.Title AS FormTitle,
						TypeLookup.Title AS TypeLookupTitle")
                .LeftJoin("[Flow].[Form] Form",  "FormAction.FormId = Form.Id  AND  Form.IsDeleted=0")
                .LeftJoin("[Core].[ModelPropertyLookup] TypeLookup",  "FormAction.TypeLookup = TypeLookup.Value AND TypeLookup.ModelPropertyId=@TypeLookup  AND  TypeLookup.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[FormAction].[{fieldName}]";
    }
}