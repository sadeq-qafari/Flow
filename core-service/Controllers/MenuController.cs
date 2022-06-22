using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Operations.Menu;
using Core.Operations.Menu.Commands;
using Core.Operations.Menu.Dto;
using Core.Operations.Menu.Queries;
using Meteor.AspCore.Filters;
using Meteor.AspCore.Utils;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Saanaa.Core.AspNetCore.Security;
using Saanaa.Core.Meteor.Dto;

namespace Core.Controllers
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

        [NeedPermission("Core.Menu.Read")]
        [HttpGet]
        public Task<QueryPage<MenuDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetMenuPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetMenuAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Core.Menu.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Menu>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetMenuByIds>().ExecuteAsync(m);

        [NeedPermission("Core.Menu.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetMenuExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Menu.xlsx");


        [NeedPermission("Core.Menu.Read")]
        [HttpGet("{id}")]
        public Task<Menu?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetMenu>().ExecuteAsync(m);

        [NeedPermission("Core.Menu.Create")]
        [HttpPost]
        public Task<long> Add(AddMenuInDto m) =>
            _operationFactory.New<AddMenu>().ExecuteAsync(m);

        [NeedPermission("Core.Menu.Update")]
        [HttpPut]
        public Task<bool> Update(UpdateMenuInDto m) =>
            _operationFactory.New<UpdateMenu>().ExecuteAsync(m);

        [NeedPermission("Core.Menu.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<RemoveMenu>().ExecuteAsync(m);

        // ============== Custom Actions:

        [NeedPermission]
        [HttpGet("user")]
        public async Task<List<GetMenuByUserDto>?> GetMenuByUser()
        {
            // await this.LogUserAgent(_operationFactory);
            // var x = await _operationFactory.New<EntityTagMerge>().ExecuteAsync(new EntityTagMergeInDto
            // {
            //     CreatedBy = 10, EntityId = 20, ModelName = "Hotel", ServiceName = "Residence", TagIds = new List<int> {1, 2, 3},
            //     TenantId = 5
            // });
            return await _operationFactory.New<GetMenuByUser>().ExecuteAsync(new GetMenuByUserInDto
            {
                ActionBy = (int) User.GetUserId(),
                TenantId = (int?) HttpContext.Items["TenantId"],
                BranchId = (int?) HttpContext.Items["BranchId"]
            });
        }
    }
}
