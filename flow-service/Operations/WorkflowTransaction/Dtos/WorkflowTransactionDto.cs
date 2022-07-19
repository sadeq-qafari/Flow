namespace Flow.Operations.WorkflowTransaction.Dtos
{
    public class WorkflowTransactionDto : WorkflowTransaction
    {
        public string? WorkflowLeadTitle { get; set; }
        public string? WorkflowStepTitle { get; set; }
        public string? ActionTypeLookupTitle { get; set; }
    }
}
