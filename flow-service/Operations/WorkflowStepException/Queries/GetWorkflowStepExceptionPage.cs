using Core.Meteor;
using Flow.Operations.WorkflowStepException.Dtos;
using Meteor.Database.SqlDialect;

namespace Flow.Operations.WorkflowStepException.Queries
{
    public class GetWorkflowStepExceptionPage : DbQueryPage<WorkflowStepExceptionDto>
    {
        public GetWorkflowStepExceptionPage() : base("[Flow].[WorkflowStepException]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            
            return SqlFactory!.Create().Select("[Flow].[WorkflowStepException] WorkflowStepException", isForCount ? "COUNT(*)" : @"
						WorkflowStepException.*, 
						WorkFlowStep.Title AS WorkFlowStepTitle,
						FormProperty.Title AS FormPropertyTitle")
                .LeftJoin("[Flow].[WorkflowStep] WorkFlowStep",  "WorkflowStepException.WorkFlowStepId = WorkFlowStep.Id  AND  WorkFlowStep.IsDeleted=0")
                .LeftJoin("[Flow].[FormProperty] FormProperty",  "WorkflowStepException.FormPropertyId = FormProperty.Id  AND  FormProperty.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[WorkflowStepException].[{fieldName}]";
    }
}