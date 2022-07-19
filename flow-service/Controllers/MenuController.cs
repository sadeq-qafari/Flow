using System.Collections.Generic;
using System.Threading.Tasks;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;
using Flow.Operations.Menu;
using Flow.Operations.Menu.Commands;
using Flow.Operations.Menu.Dto;
using Flow.Operations.Menu.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly OperationFactory _operationFactory;

        public MenuController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Flow.Menu.Read")]
        [HttpGet]
        public Task<QueryPage<MenuDto>?> Get([FromQuery] DbQueryPageInDto m) =>
            _operationFactory.New<GetMenuPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetMenuAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Flow.Menu.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Menu>?> GetByIds([FromQuery] DbQueryByIdsInDto m) =>
            _operationFactory.New<GetMenuByIds>().ExecuteAsync(m);

        [NeedPermission("Flow.Menu.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetMenuExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Menu.xlsx");


        [NeedPermission("Flow.Menu.Read")]
        [HttpGet("list")]
        public Task<List<MenuModel>?> GetMenu() =>
            _operationFactory.New<GetMenu>().ExecuteAsync();

        [NeedPermission("Flow.Menu.Create")]
        [HttpPost]
        public Task<long> Add(AddMenuInDto m) =>
            _operationFactory.New<AddMenu>().ExecuteAsync(m);

        [NeedPermission("Flow.Menu.Update")]
        [HttpPut]
        public Task<bool> Update(UpdateMenuInDto m) =>
            _operationFactory.New<UpdateMenu>().ExecuteAsync(m);

        [NeedPermission("Flow.Menu.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<RemoveMenu>().ExecuteAsync(m);
    }
}
