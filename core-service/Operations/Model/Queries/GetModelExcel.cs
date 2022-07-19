using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Core.Operations.Model.Dto;
using Meteor.Operation;

namespace Core.Operations.Model.Queries
{
    public class GetModelExcel : DbQueryExcel<ModelDto>
    {
        public GetModelExcel() : base("[Core].[Model]")
        {
        }

        protected override async Task<List<ModelDto>?> GetItems() =>
            (await OperationFactory!.New<GetModelPage>().ExecuteAsync(Input))?.Items;
    }
}
