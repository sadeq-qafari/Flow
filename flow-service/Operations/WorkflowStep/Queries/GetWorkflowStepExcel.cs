using System.Collections.Generic;
using System.Threading.Tasks;
using Flow.Operations.WorkflowStep.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowStep.Queries
{
    public class GetWorkflowStepExcel : SaanaaDbQueryExcel<WorkflowStepDto>
    {
        public GetWorkflowStepExcel() : base("[Flow].[WorkflowStep]")
        {
        }
        
        protected override async Task<List<WorkflowStepDto>?> GetItems() =>
            (await OperationFactory!.New<GetWorkflowStepPage>().ExecuteAsync(Input))?.Items;
    }
}