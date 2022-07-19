using Core.Meteor;
using Flow.Operations.FormLeadData.Dtos;
using Meteor.Database.SqlDialect;

namespace Flow.Operations.FormLeadData.Queries
{
    public class GetFormLeadDataPage : DbQueryPage<FormLeadDataDto>
    {
        public GetFormLeadDataPage() : base("[Flow].[FormLeadData]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            
            return SqlFactory!.Create().Select("[Flow].[FormLeadData] FormLeadData", isForCount ? "COUNT(*)" : @"
						FormLeadData.*, 
						FormLead.Title AS FormLeadTitle,
						FormProperty.Title AS FormPropertyTitle")
                .LeftJoin("[Flow].[FormLead] FormLead",  "FormLeadData.FormLeadId = FormLead.Id  AND  FormLead.IsDeleted=0")
                .LeftJoin("[Flow].[FormProperty] FormProperty",  "FormLeadData.FormPropertyId = FormProperty.Id  AND  FormProperty.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[FormLeadData].[{fieldName}]";
    }
}