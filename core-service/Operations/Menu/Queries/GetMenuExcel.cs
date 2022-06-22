using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Operations.Menu.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.Menu.Queries
{
    public class GetMenuExcel : SaanaaDbQueryExcel<MenuDto>
    {
        public GetMenuExcel() : base("[Core].[Menu]")
        {
        }

        protected override async Task<List<MenuDto>?> GetItems() =>
            (await OperationFactory!.New<GetMenuPage>().ExecuteAsync(Input))?.Items;
    }
}
