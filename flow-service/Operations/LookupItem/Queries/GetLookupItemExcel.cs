using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Flow.Operations.LookupItem.Dtos;
using Meteor.Operation;

namespace Flow.Operations.LookupItem.Queries
{
    public class GetLookupItemExcel : DbQueryExcel<LookupItemDto>
    {
        public GetLookupItemExcel() : base("[Flow].[LookupItem]")
        {
        }
        
        protected override async Task<List<LookupItemDto>?> GetItems() =>
            (await OperationFactory!.New<GetLookupItemPage>().ExecuteAsync(Input))?.Items;
    }
}