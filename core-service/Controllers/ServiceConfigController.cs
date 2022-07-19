using System.Collections.Generic;
using System.Threading.Tasks;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;
using Core.Operations.ServiceConfig;
using Core.Operations.ServiceConfig.Commands;
using Core.Operations.ServiceConfig.Dto;
using Core.Operations.ServiceConfig.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class ServiceConfigController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public ServiceConfigController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Core.ServiceConfig.Read")]
        [HttpGet]
        public Task<QueryPage<ServiceConfigDto>?> Get([FromQuery] DbQueryPageInDto m) =>
            _operationFactory.New<GetServiceConfigPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetServiceConfigAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Core.ServiceConfig.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<ServiceConfig>?> GetByIds([FromQuery] DbQueryByIdsInDto m) =>
            _operationFactory.New<GetServiceConfigByIds>().ExecuteAsync(m);

        [NeedPermission("Core.ServiceConfig.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetServiceConfigExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ServiceConfig.xlsx");


        [NeedPermission("Core.ServiceConfig.Read")]
        [HttpGet("{id}")]
        public Task<ServiceConfig?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetServiceConfig>().ExecuteAsync(m);

        [NeedPermission("Core.ServiceConfig.Create")]
        [HttpPost]
        public Task<long> Add(AddServiceConfigInDto m) =>
            _operationFactory.New<AddServiceConfig>().ExecuteAsync(m);

        [NeedPermission("Core.ServiceConfig.Update")]
        [HttpPut]
        public Task<bool> Update(UpdateServiceConfigInDto m) =>
            _operationFactory.New<UpdateServiceConfig>().ExecuteAsync(m);

        [NeedPermission("Core.ServiceConfig.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<RemoveServiceConfig>().ExecuteAsync(m);
    }
}
