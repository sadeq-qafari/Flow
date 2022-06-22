using Flow.Operations.WorkflowStep.Dtos;
using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowStep.Queries
{
    public class GetWorkflowStepPage : SaanaaDbQueryPage<WorkflowStepDto>
    {
        public GetWorkflowStepPage() : base("[Flow].[WorkflowStep]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            Parameters.Add("DeterminerTypeLookup", SaanaaServices.GetModelProperty("Flow","WorkflowStep","determinerTypeLookup")!.Id);
            return SqlFactory!.Create().Select("[Flow].[WorkflowStep] WorkflowStep", isForCount ? "COUNT(*)" : @"
						WorkflowStep.*, 
						Workflow.Title AS WorkflowTitle,
						DeterminerTypeLookup.Title AS DeterminerTypeLookupTitle,
						Role.Title AS RoleTitle,
						User.Title AS UserTitle,
						AcceptWorkflowStep.Title AS AcceptWorkflowStepTitle,
						RejectWorkflowStep.Title AS RejectWorkflowStepTitle,
						Message.Title AS MessageTitle")
                .LeftJoin("[Flow].[Workflow] Workflow",  "WorkflowStep.WorkflowId = Workflow.Id  AND  Workflow.IsDeleted=0")
                .LeftJoin("[Core].[ModelPropertyLookup] DeterminerTypeLookup",  "WorkflowStep.DeterminerTypeLookup = DeterminerTypeLookup.Value AND DeterminerTypeLookup.ModelPropertyId=@DeterminerTypeLookup  AND  DeterminerTypeLookup.IsDeleted=0")
                .LeftJoin("[Identity].[Role] Role",  "WorkflowStep.RoleId = Role.Id  AND  Role.IsDeleted=0")
                .LeftJoin("[Accounting].[User] User",  "WorkflowStep.UserId = User.Id  AND  User.IsDeleted=0")
                .LeftJoin("[Flow].[WorkflowStep] AcceptWorkflowStep",  "WorkflowStep.AcceptWorkflowStepId = AcceptWorkflowStep.Id  AND  AcceptWorkflowStep.IsDeleted=0")
                .LeftJoin("[Flow].[WorkflowStep] RejectWorkflowStep",  "WorkflowStep.RejectWorkflowStepId = RejectWorkflowStep.Id  AND  RejectWorkflowStep.IsDeleted=0")
                .LeftJoin("[Notify].[Message] Message",  "WorkflowStep.MessageId = Message.Id  AND  Message.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[WorkflowStep].[{fieldName}]";
    }
}