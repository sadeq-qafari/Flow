using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Flow.Operations.Workflow.Dtos;
using Meteor.Operation;

namespace Flow.Operations.Workflow.Queries
{
    public class GetWorkflowExcel : DbQueryExcel<WorkflowDto>
    {
        public GetWorkflowExcel() : base("[Flow].[Workflow]")
        {
        }
        
        protected override async Task<List<WorkflowDto>?> GetItems() =>
            (await OperationFactory!.New<GetWorkflowPage>().ExecuteAsync(Input))?.Items;
    }
}