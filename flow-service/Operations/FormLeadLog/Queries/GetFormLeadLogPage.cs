using Flow.Operations.FormLeadLog.Dtos;
using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;

namespace Flow.Operations.FormLeadLog.Queries
{
    public class GetFormLeadLogPage : SaanaaDbQueryPage<FormLeadLogDto>
    {
        public GetFormLeadLogPage() : base("[Flow].[FormLeadLog]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            Parameters.Add("ActionLookup", SaanaaServices.GetModelProperty("Flow","FormLeadLog","actionLookup")!.Id);
            return SqlFactory!.Create().Select("[Flow].[FormLeadLog] FormLeadLog", isForCount ? "COUNT(*)" : @"
						FormLeadLog.*, 
						FormLead.Title AS FormLeadTitle,
						Form.Title AS FormTitle,
						ActionLookup.Title AS ActionLookupTitle")
                .LeftJoin("[Flow].[FormLead] FormLead",  "FormLeadLog.FormLeadId = FormLead.Id  AND  FormLead.IsDeleted=0")
                .LeftJoin("[Flow].[Form] Form",  "FormLeadLog.FormId = Form.Id  AND  Form.IsDeleted=0")
                .LeftJoin("[Core].[ModelPropertyLookup] ActionLookup",  "FormLeadLog.ActionLookup = ActionLookup.Value AND ActionLookup.ModelPropertyId=@ActionLookup  AND  ActionLookup.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[FormLeadLog].[{fieldName}]";
    }
}