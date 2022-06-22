namespace Flow.Operations.WorkflowStepException.Dtos
{
    public class WorkflowStepExceptionDto : WorkflowStepException
    {
        public string? WorkFlowStepTitle { get; set; }
        public string? FormPropertyTitle { get; set; }
    }
}
