using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Operations.ModelFilter.Dtos;
using Saanaa.Core.Meteor;

namespace Core.Operations.ModelFilter.Queries
{
    public class GetModelFilterExcel : SaanaaDbQueryExcel<ModelFilterDto>
    {
        public GetModelFilterExcel() : base("[Core].[ModelFilter]")
        {
        }
        
        protected override async Task<List<ModelFilterDto>?> GetItems() =>
            (await OperationFactory!.New<GetModelFilterPage>().ExecuteAsync(Input))?.Items;
    }
}
