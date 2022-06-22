using System.Collections.Generic;
using System.Threading.Tasks;
using Flow.Operations.FormLeadData.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.FormLeadData.Queries
{
    public class GetFormLeadDataExcel : SaanaaDbQueryExcel<FormLeadDataDto>
    {
        public GetFormLeadDataExcel() : base("[Flow].[FormLeadData]")
        {
        }
        
        protected override async Task<List<FormLeadDataDto>?> GetItems() =>
            (await OperationFactory!.New<GetFormLeadDataPage>().ExecuteAsync(Input))?.Items;
    }
}