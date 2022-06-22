using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Operations.Database.DeviceCode;
using Identity.Operations.Database.DeviceCode.Commands;
using Identity.Operations.Database.DeviceCode.Dtos;
using Identity.Operations.Database.DeviceCode.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Saanaa.Core.AspNetCore.Security;
using Saanaa.Core.Meteor.Dto;

namespace Identity.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class DeviceCodeController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public DeviceCodeController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Identity.DeviceCode.Read")]
        [HttpGet]
        public Task<QueryPage<DeviceCodeDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetDeviceCodePage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetDeviceCodeAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Identity.DeviceCode.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<DeviceCode>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetDeviceCodeByIds>().ExecuteAsync(m);

        [NeedPermission("Identity.DeviceCode.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetDeviceCodeExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DeviceCode.xlsx");


        [NeedPermission("Identity.DeviceCode.Read")]
        [HttpGet("{id}")]
        public Task<DeviceCode?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetDeviceCode>().ExecuteAsync(m);

        [NeedPermission("Identity.DeviceCode.Create")]
        [HttpPost]
        public Task<long> Add(DeviceCodeAddInDto m) =>
            _operationFactory.New<DeviceCodeAdd>().ExecuteAsync(m);

        [NeedPermission("Identity.DeviceCode.Update")]
        [HttpPut]
        public Task<bool> Update(DeviceCodeUpdateInDto m) =>
            _operationFactory.New<DeviceCodeUpdate>().ExecuteAsync(m);

        [NeedPermission("Identity.DeviceCode.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<DeviceCodeRemove>().ExecuteAsync(m);
    }
}
