using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Core.Operations.ModelProperty.Dto;
using Meteor.Operation;

namespace Core.Operations.ModelProperty.Queries
{
    public class GetModelPropertyExcel : DbQueryExcel<ModelPropertyDto>
    {
        public GetModelPropertyExcel() : base("[Core].[ModelProperty]")
        {
        }
        
        protected override async Task<List<ModelPropertyDto>?> GetItems() =>
            (await OperationFactory!.New<GetModelPropertyPage>().ExecuteAsync(Input))?.Items;
    }
}