using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Core.Operations.ModelPropertyDatagrid.Dto;
using Meteor.Operation;

namespace Core.Operations.ModelPropertyDatagrid.Queries
{
    public class GetModelPropertyDatagridExcel : DbQueryExcel<ModelPropertyDatagridDto>
    {
        public GetModelPropertyDatagridExcel() : base("[Core].[ModelPropertyDatagrid]")
        {
        }
        
        protected override async Task<List<ModelPropertyDatagridDto>?> GetItems() =>
            (await OperationFactory!.New<GetModelPropertyDatagridPage>().ExecuteAsync(Input))?.Items;
    }
}