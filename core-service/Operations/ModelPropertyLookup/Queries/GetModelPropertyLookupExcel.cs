using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Core.Operations.ModelPropertyLookup.Dto;
using Meteor.Operation;

namespace Core.Operations.ModelPropertyLookup.Queries
{
    public class GetModelPropertyLookupExcel : DbQueryExcel<ModelPropertyLookupDto>
    {
        public GetModelPropertyLookupExcel() : base("[Core].[ModelPropertyLookup]")
        {
        }
        
        protected override async Task<List<ModelPropertyLookupDto>?> GetItems() =>
            (await OperationFactory!.New<GetModelPropertyLookupPage>().ExecuteAsync(Input))?.Items;
    }
}