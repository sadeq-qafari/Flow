using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Core.Operations.ModelFilter.Dtos;
using Meteor.Operation;

namespace Core.Operations.ModelFilter.Queries
{
    public class GetModelFilterExcel : DbQueryExcel<ModelFilterDto>
    {
        public GetModelFilterExcel() : base("[Core].[ModelFilter]")
        {
        }
        
        protected override async Task<List<ModelFilterDto>?> GetItems() =>
            (await OperationFactory!.New<GetModelFilterPage>().ExecuteAsync(Input))?.Items;
    }
}
