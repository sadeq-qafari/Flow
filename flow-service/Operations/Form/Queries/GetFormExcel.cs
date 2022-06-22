using System.Collections.Generic;
using System.Threading.Tasks;
using Flow.Operations.Form.Dtos;
using Saanaa.Core.Meteor; //

namespace Flow.Operations.Form.Queries
{
    public class GetFormExcel : SaanaaDbQueryExcel<FormDto>
    {
        public GetFormExcel() : base("[Flow].[Form]")
        {
        }
        
        protected override async Task<List<FormDto>?> GetItems() =>
            (await OperationFactory!.New<GetFormPage>().ExecuteAsync(Input))?.Items;
    }
}