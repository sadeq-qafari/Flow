using System.Collections.Generic;
using System.Threading.Tasks;
using Flow.Operations.Workflow.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.Workflow.Queries
{
    public class GetWorkflowExcel : SaanaaDbQueryExcel<WorkflowDto>
    {
        public GetWorkflowExcel() : base("[Flow].[Workflow]")
        {
        }
        
        protected override async Task<List<WorkflowDto>?> GetItems() =>
            (await OperationFactory!.New<GetWorkflowPage>().ExecuteAsync(Input))?.Items;
    }
}