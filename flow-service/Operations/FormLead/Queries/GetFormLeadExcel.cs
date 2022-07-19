using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Flow.Operations.FormLead.Dtos;
using Meteor.Operation;

namespace Flow.Operations.FormLead.Queries
{
    public class GetFormLeadExcel : DbQueryExcel<FormLeadDto>
    {
        public GetFormLeadExcel() : base("[Flow].[FormLead]")
        {
        }
        
        protected override async Task<List<FormLeadDto>?> GetItems() =>
            (await OperationFactory!.New<GetFormLeadPage>().ExecuteAsync(Input))?.Items;
    }
}