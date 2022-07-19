using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Flow.Operations.WorkflowStepException.Dtos;
using Meteor.Operation;

namespace Flow.Operations.WorkflowStepException.Queries
{
    public class GetWorkflowStepExceptionExcel : DbQueryExcel<WorkflowStepExceptionDto>
    {
        public GetWorkflowStepExceptionExcel() : base("[Flow].[WorkflowStepException]")
        {
        }
        
        protected override async Task<List<WorkflowStepExceptionDto>?> GetItems() =>
            (await OperationFactory!.New<GetWorkflowStepExceptionPage>().ExecuteAsync(Input))?.Items;
    }
}