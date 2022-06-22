using System.Collections.Generic;
using System.Threading.Tasks;
using Flow.Operations.WorkflowStepException.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowStepException.Queries
{
    public class GetWorkflowStepExceptionExcel : SaanaaDbQueryExcel<WorkflowStepExceptionDto>
    {
        public GetWorkflowStepExceptionExcel() : base("[Flow].[WorkflowStepException]")
        {
        }
        
        protected override async Task<List<WorkflowStepExceptionDto>?> GetItems() =>
            (await OperationFactory!.New<GetWorkflowStepExceptionPage>().ExecuteAsync(Input))?.Items;
    }
}