namespace Flow.Operations.WorkflowStep.Dtos
{
    public class WorkflowStepDto : WorkflowStep
    {
        public string? WorkflowTitle { get; set; }
        public string? DeterminerTypeLookupTitle { get; set; }
        public string? RoleTitle { get; set; }
        public string? UserTitle { get; set; }
        public string? AcceptWorkflowStepTitle { get; set; }
        public string? RejectWorkflowStepTitle { get; set; }
        public string? MessageTitle { get; set; }
    }
}
