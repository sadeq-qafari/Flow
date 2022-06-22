using System.Collections.Generic;
using System.Threading.Tasks;
using Flow.Operations.WorkflowLead.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.WorkflowLead.Queries
{
    public class GetWorkflowLeadExcel : SaanaaDbQueryExcel<WorkflowLeadDto>
    {
        public GetWorkflowLeadExcel() : base("[Flow].[WorkflowLead]")
        {
        }
        
        protected override async Task<List<WorkflowLeadDto>?> GetItems() =>
            (await OperationFactory!.New<GetWorkflowLeadPage>().ExecuteAsync(Input))?.Items;
    }
}