using Core.Meteor.Dto;

namespace Flow.Operations.WorkflowStep.Dtos
{
    public class WorkflowStepAddInDto : DbInsertInDto
    {
        public int WorkflowId { get; set; }
        public string Title { get; set; }
        public int Index { get; set; }
        public int? DeterminerTypeLookup { get; set; }
        public int? RoleId { get; set; }
        public int? UserId { get; set; }
        public string? Conditions { get; set; }
        public int? AcceptWorkflowStepId { get; set; }
        public int? RejectWorkflowStepId { get; set; }
        public string? AcceptText { get; set; }
        public string? RejectText { get; set; }
        public int MessageId { get; set; }
        public bool IsLastStep { get; set; }
        public string? Url { get; set; }
        public string? Description { get; set; }
        public string? Guidance { get; set; }
        public bool ShowReject { get; set; }

    }
}
