using System.Collections.Generic;
using System.Threading.Tasks;
using Flow.Operations.Lookup.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.Lookup.Queries
{
    public class GetLookupExcel : SaanaaDbQueryExcel<LookupDto>
    {
        public GetLookupExcel() : base("[Flow].[Lookup]")
        {
        }
        
        protected override async Task<List<LookupDto>?> GetItems() =>
            (await OperationFactory!.New<GetLookupPage>().ExecuteAsync(Input))?.Items;
    }
}