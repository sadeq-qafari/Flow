using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Flow.Operations.Element.Dtos;
using Meteor.Operation;

namespace Flow.Operations.Element.Queries
{
    public class GetElementExcel : DbQueryExcel<ElementDto>
    {
        public GetElementExcel() : base("[Flow].[Element]")
        {
        }
        
        protected override async Task<List<ElementDto>?> GetItems() =>
            (await OperationFactory!.New<GetElementPage>().ExecuteAsync(Input))?.Items;
    }
}