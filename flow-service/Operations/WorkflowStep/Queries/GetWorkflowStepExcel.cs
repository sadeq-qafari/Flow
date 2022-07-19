using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Flow.Operations.WorkflowStep.Dtos;
using Meteor.Operation;

namespace Flow.Operations.WorkflowStep.Queries
{
    public class GetWorkflowStepExcel : DbQueryExcel<WorkflowStepDto>
    {
        public GetWorkflowStepExcel() : base("[Flow].[WorkflowStep]")
        {
        }
        
        protected override async Task<List<WorkflowStepDto>?> GetItems() =>
            (await OperationFactory!.New<GetWorkflowStepPage>().ExecuteAsync(Input))?.Items;
    }
}