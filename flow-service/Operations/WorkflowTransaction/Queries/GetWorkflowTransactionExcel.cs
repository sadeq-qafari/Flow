using System.Collections.Generic;
using System.Threading.Tasks;
using Flow.Operations.WorkflowTransaction.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowTransaction.Queries
{
    public class GetWorkflowTransactionExcel : SaanaaDbQueryExcel<WorkflowTransactionDto>
    {
        public GetWorkflowTransactionExcel() : base("[Flow].[WorkflowTransaction]")
        {
        }
        
        protected override async Task<List<WorkflowTransactionDto>?> GetItems() =>
            (await OperationFactory!.New<GetWorkflowTransactionPage>().ExecuteAsync(Input))?.Items;
    }
}