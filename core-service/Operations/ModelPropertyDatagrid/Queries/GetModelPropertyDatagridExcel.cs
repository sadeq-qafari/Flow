using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Operations.ModelPropertyDatagrid.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.ModelPropertyDatagrid.Queries
{
    public class GetModelPropertyDatagridExcel : SaanaaDbQueryExcel<ModelPropertyDatagridDto>
    {
        public GetModelPropertyDatagridExcel() : base("[Core].[ModelPropertyDatagrid]")
        {
        }
        
        protected override async Task<List<ModelPropertyDatagridDto>?> GetItems() =>
            (await OperationFactory!.New<GetModelPropertyDatagridPage>().ExecuteAsync(Input))?.Items;
    }
}