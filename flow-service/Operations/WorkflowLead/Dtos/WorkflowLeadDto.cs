namespace Flow.Operations.WorkflowLead.Dtos
{
    public class WorkflowLeadDto : WorkflowLead
    {
        public string? CurrentWorkflowStepTitle { get; set; }
        public string? StatusLookupTitle { get; set; }
    }
}
