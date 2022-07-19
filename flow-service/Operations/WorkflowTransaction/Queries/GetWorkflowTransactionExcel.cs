using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Flow.Operations.WorkflowTransaction.Dtos;
using Meteor.Operation;

namespace Flow.Operations.WorkflowTransaction.Queries
{
    public class GetWorkflowTransactionExcel : DbQueryExcel<WorkflowTransactionDto>
    {
        public GetWorkflowTransactionExcel() : base("[Flow].[WorkflowTransaction]")
        {
        }
        
        protected override async Task<List<WorkflowTransactionDto>?> GetItems() =>
            (await OperationFactory!.New<GetWorkflowTransactionPage>().ExecuteAsync(Input))?.Items;
    }
}