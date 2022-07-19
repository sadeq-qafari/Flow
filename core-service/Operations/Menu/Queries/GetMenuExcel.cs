using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Core.Operations.Menu.Dto;
using Meteor.Operation;

namespace Core.Operations.Menu.Queries
{
    public class GetMenuExcel : DbQueryExcel<MenuDto>
    {
        public GetMenuExcel() : base("[Core].[Menu]")
        {
        }

        protected override async Task<List<MenuDto>?> GetItems() =>
            (await OperationFactory!.New<GetMenuPage>().ExecuteAsync(Input))?.Items;
    }
}
