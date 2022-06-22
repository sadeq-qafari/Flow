using System.Collections.Generic;
using System.Threading.Tasks;
using Flow.Operations.LookupItem.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.LookupItem.Queries
{
    public class GetLookupItemExcel : SaanaaDbQueryExcel<LookupItemDto>
    {
        public GetLookupItemExcel() : base("[Flow].[LookupItem]")
        {
        }
        
        protected override async Task<List<LookupItemDto>?> GetItems() =>
            (await OperationFactory!.New<GetLookupItemPage>().ExecuteAsync(Input))?.Items;
    }
}