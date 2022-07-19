using Core.Meteor;
using Flow.Operations.WorkflowTransaction.Dtos;
using Meteor.Database.SqlDialect;

namespace Flow.Operations.WorkflowTransaction.Queries
{
    public class GetWorkflowTransactionPage : DbQueryPage<WorkflowTransactionDto>
    {
        public GetWorkflowTransactionPage() : base("[Flow].[WorkflowTransaction]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            Parameters.Add("ActionTypeLookup", SqServices.GetModelProperty("Flow","WorkflowTransaction","actionTypeLookup")!.Id);
            return SqlFactory!.Create().Select("[Flow].[WorkflowTransaction] WorkflowTransaction", isForCount ? "COUNT(*)" : @"
						WorkflowTransaction.*, 
						WorkflowLead.Title AS WorkflowLeadTitle,
						WorkflowStep.Title AS WorkflowStepTitle,
						ActionTypeLookup.Title AS ActionTypeLookupTitle")
                .LeftJoin("[Flow].[WorkflowLead] WorkflowLead",  "WorkflowTransaction.WorkflowLeadId = WorkflowLead.Id  AND  WorkflowLead.IsDeleted=0")
                .LeftJoin("[Flow].[WorkflowStep] WorkflowStep",  "WorkflowTransaction.WorkflowStepId = WorkflowStep.Id  AND  WorkflowStep.IsDeleted=0")
                .LeftJoin("[Core].[ModelPropertyLookup] ActionTypeLookup",  "WorkflowTransaction.ActionTypeLookup = ActionTypeLookup.Value AND ActionTypeLookup.ModelPropertyId=@ActionTypeLookup  AND  ActionTypeLookup.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[WorkflowTransaction].[{fieldName}]";
    }
}