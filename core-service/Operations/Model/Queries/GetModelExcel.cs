using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Operations.Model.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.Model.Queries
{
    public class GetModelExcel : SaanaaDbQueryExcel<ModelDto>
    {
        public GetModelExcel() : base("[Core].[Model]")
        {
        }

        protected override async Task<List<ModelDto>?> GetItems() =>
            (await OperationFactory!.New<GetModelPage>().ExecuteAsync(Input))?.Items;
    }
}
