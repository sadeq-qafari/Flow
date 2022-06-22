using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Operations.ModelProperty.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.ModelProperty.Queries
{
    public class GetModelPropertyExcel : SaanaaDbQueryExcel<ModelPropertyDto>
    {
        public GetModelPropertyExcel() : base("[Core].[ModelProperty]")
        {
        }
        
        protected override async Task<List<ModelPropertyDto>?> GetItems() =>
            (await OperationFactory!.New<GetModelPropertyPage>().ExecuteAsync(Input))?.Items;
    }
}