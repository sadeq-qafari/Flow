using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Operations.Database.TenantService;
using Identity.Operations.Database.TenantService.Commands;
using Identity.Operations.Database.TenantService.Dtos;
using Identity.Operations.Database.TenantService.Queries;
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
    public class TenantServiceController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public TenantServiceController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Identity.TenantService.Read")]
        [HttpGet]
        public Task<QueryPage<TenantServiceDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetTenantServicePage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetTenantServiceAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Identity.TenantService.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<TenantService>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetTenantServiceByIds>().ExecuteAsync(m);

        [NeedPermission("Identity.TenantService.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetTenantServiceExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "TenantService.xlsx");


        [NeedPermission("Identity.TenantService.Read")]
        [HttpGet("{id}")]
        public Task<TenantService?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetTenantService>().ExecuteAsync(m);

        [NeedPermission("Identity.TenantService.Create")]
        [HttpPost]
        public Task<long> Add(TenantServiceAddInDto m) =>
            _operationFactory.New<TenantServiceAdd>().ExecuteAsync(m);

        [NeedPermission("Identity.TenantService.Update")]
        [HttpPut]
        public Task<bool> Update(TenantServiceUpdateInDto m) =>
            _operationFactory.New<TenantServiceUpdate>().ExecuteAsync(m);

        [NeedPermission("Identity.TenantService.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<TenantServiceRemove>().ExecuteAsync(m);
    }
}
