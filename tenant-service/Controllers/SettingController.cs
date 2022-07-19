using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;
using Tenant.Operations.Setting;
using Tenant.Operations.Setting.Commands;
using Tenant.Operations.Setting.Dto;
using Tenant.Operations.Setting.Queries;

namespace Tenant.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class SettingController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public SettingController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Tenant.Setting.Read")]
        [HttpGet]
        public Task<QueryPage<SettingDto>?> Get([FromQuery] DbQueryPageInDto m) =>
            _operationFactory.New<GetSettingPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetSettingAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Tenant.Setting.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Setting>?> GetByIds([FromQuery] DbQueryByIdsInDto m) =>
            _operationFactory.New<GetSettingByIds>().ExecuteAsync(m);

        [NeedPermission("Tenant.Setting.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetSettingExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Setting.xlsx");


        [NeedPermission("Tenant.Setting.Read")]
        [HttpGet("{id}")]
        public Task<Setting?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetSetting>().ExecuteAsync(m);

        [NeedPermission("Tenant.Setting.Create")]
        [HttpPost]
        public Task<long> Add(AddSettingInDto m) =>
            _operationFactory.New<AddSetting>().ExecuteAsync(m);

        [NeedPermission("Tenant.Setting.Update")]
        [HttpPut]
        public Task<bool> Update(UpdateSettingInDto m) =>
            _operationFactory.New<UpdateSetting>().ExecuteAsync(m);

        [NeedPermission("Tenant.Setting.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<RemoveSetting>().ExecuteAsync(m);
    }
}
