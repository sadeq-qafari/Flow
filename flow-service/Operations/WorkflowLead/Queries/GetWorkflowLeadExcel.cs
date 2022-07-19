using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Flow.Operations.WorkflowLead.Dtos;
using Meteor.Operation;

namespace Flow.Operations.WorkflowLead.Queries
{
    public class GetWorkflowLeadExcel : DbQueryExcel<WorkflowLeadDto>
    {
        public GetWorkflowLeadExcel() : base("[Flow].[WorkflowLead]")
        {
        }
        
        protected override async Task<List<WorkflowLeadDto>?> GetItems() =>
            (await OperationFactory!.New<GetWorkflowLeadPage>().ExecuteAsync(Input))?.Items;
    }
}