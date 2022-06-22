using System.Collections.Generic;
using System.Threading.Tasks;
using Flow.Operations.Menu.Dto;
using Saanaa.Core.Meteor;

namespace Flow.Operations.Menu.Queries
{
    public class GetMenuExcel : SaanaaDbQueryExcel<MenuDto>
    {
        public GetMenuExcel() : base("[Flow].[Menu]")
        {
        }

        protected override async Task<List<MenuDto>?> GetItems() =>
            (await OperationFactory!.New<GetMenuPage>().ExecuteAsync(Input))?.Items;
    }
}
