using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Operations.ModelPropertyElement.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.ModelPropertyElement.Queries
{
    public class GetModelPropertyElementExcel : SaanaaDbQueryExcel<ModelPropertyElementDto>
    {
        public GetModelPropertyElementExcel() : base("[Core].[ModelPropertyElement]")
        {
        }
        
        protected override async Task<List<ModelPropertyElementDto>?> GetItems() =>
            (await OperationFactory!.New<GetModelPropertyElementPage>().ExecuteAsync(Input))?.Items;
    }
}