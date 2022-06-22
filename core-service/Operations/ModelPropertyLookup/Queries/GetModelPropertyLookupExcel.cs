using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Operations.ModelPropertyLookup.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.ModelPropertyLookup.Queries
{
    public class GetModelPropertyLookupExcel : SaanaaDbQueryExcel<ModelPropertyLookupDto>
    {
        public GetModelPropertyLookupExcel() : base("[Core].[ModelPropertyLookup]")
        {
        }
        
        protected override async Task<List<ModelPropertyLookupDto>?> GetItems() =>
            (await OperationFactory!.New<GetModelPropertyLookupPage>().ExecuteAsync(Input))?.Items;
    }
}