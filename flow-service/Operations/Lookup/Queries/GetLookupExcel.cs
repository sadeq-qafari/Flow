using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Flow.Operations.Lookup.Dtos;
using Meteor.Operation;

namespace Flow.Operations.Lookup.Queries
{
    public class GetLookupExcel : DbQueryExcel<LookupDto>
    {
        public GetLookupExcel() : base("[Flow].[Lookup]")
        {
        }
        
        protected override async Task<List<LookupDto>?> GetItems() =>
            (await OperationFactory!.New<GetLookupPage>().ExecuteAsync(Input))?.Items;
    }
}