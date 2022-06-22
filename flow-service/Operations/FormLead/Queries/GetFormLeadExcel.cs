using System.Collections.Generic;
using System.Threading.Tasks;
using Flow.Operations.FormLead.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.FormLead.Queries
{
    public class GetFormLeadExcel : SaanaaDbQueryExcel<FormLeadDto>
    {
        public GetFormLeadExcel() : base("[Flow].[FormLead]")
        {
        }
        
        protected override async Task<List<FormLeadDto>?> GetItems() =>
            (await OperationFactory!.New<GetFormLeadPage>().ExecuteAsync(Input))?.Items;
    }
}