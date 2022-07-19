using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Core.Operations.ModelPropertyElement.Dto;
using Meteor.Operation;

namespace Core.Operations.ModelPropertyElement.Queries
{
    public class GetModelPropertyElementExcel : DbQueryExcel<ModelPropertyElementDto>
    {
        public GetModelPropertyElementExcel() : base("[Core].[ModelPropertyElement]")
        {
        }
        
        protected override async Task<List<ModelPropertyElementDto>?> GetItems() =>
            (await OperationFactory!.New<GetModelPropertyElementPage>().ExecuteAsync(Input))?.Items;
    }
}