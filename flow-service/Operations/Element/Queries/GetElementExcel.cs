using System.Collections.Generic;
using System.Threading.Tasks;
using Flow.Operations.Element.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.Element.Queries
{
    public class GetElementExcel : SaanaaDbQueryExcel<ElementDto>
    {
        public GetElementExcel() : base("[Flow].[Element]")
        {
        }
        
        protected override async Task<List<ElementDto>?> GetItems() =>
            (await OperationFactory!.New<GetElementPage>().ExecuteAsync(Input))?.Items;
    }
}