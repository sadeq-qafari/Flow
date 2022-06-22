using Flow.Operations.WorkflowLead.Dtos;
using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowLead.Queries
{
    public class GetWorkflowLeadPage : SaanaaDbQueryPage<WorkflowLeadDto>
    {
        public GetWorkflowLeadPage() : base("[Flow].[WorkflowLead]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            Parameters.Add("StatusLookup", SaanaaServices.GetModelProperty("Flow","WorkflowLead","statusLookup")!.Id);
            return SqlFactory!.Create().Select("[Flow].[WorkflowLead] WorkflowLead", isForCount ? "COUNT(*)" : @"
						WorkflowLead.*, 
						CurrentWorkflowStep.Title AS CurrentWorkflowStepTitle,
						StatusLookup.Title AS StatusLookupTitle")
                .LeftJoin("[Flow].[WorkflowLead] CurrentWorkflowStep",  "WorkflowLead.CurrentWorkflowStepId = CurrentWorkflowStep.Id  AND  CurrentWorkflowStep.IsDeleted=0")
                .LeftJoin("[Core].[ModelPropertyLookup] StatusLookup",  "WorkflowLead.StatusLookup = StatusLookup.Value AND StatusLookup.ModelPropertyId=@StatusLookup  AND  StatusLookup.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[WorkflowLead].[{fieldName}]";
    }
}