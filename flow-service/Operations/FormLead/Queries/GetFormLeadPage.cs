using Core.Meteor;
using Flow.Operations.FormLead.Dtos;
using Meteor.Database.SqlDialect;

namespace Flow.Operations.FormLead.Queries
{
    public class GetFormLeadPage : DbQueryPage<FormLeadDto>
    {
        public GetFormLeadPage() : base("[Flow].[FormLead]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            
            return SqlFactory!.Create().Select("[Flow].[FormLead] FormLead", isForCount ? "COUNT(*)" : @"
						FormLead.*, 
						Form.Title AS FormTitle")
                .LeftJoin("[Flow].[Form] Form",  "FormLead.FormId = Form.Id  AND  Form.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[FormLead].[{fieldName}]";
    }
}