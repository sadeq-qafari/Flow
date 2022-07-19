using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Flow.Operations.Menu.Dto;
using Meteor.Operation;

namespace Flow.Operations.Menu.Queries
{
    public class GetMenuExcel : DbQueryExcel<MenuDto>
    {
        public GetMenuExcel() : base("[Flow].[Menu]")
        {
        }

        protected override async Task<List<MenuDto>?> GetItems() =>
            (await OperationFactory!.New<GetMenuPage>().ExecuteAsync(Input))?.Items;
    }
}
