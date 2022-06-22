using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Operations.Database.Tenant.Commands;
using Identity.Operations.Database.Tenant.Dtos;
using Identity.Operations.Database.Tenant.Queries;
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
    public class TenantController : ControllerBase
    {
        private readonly OperationFactory _operationFactory;

        public TenantController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Identity.Tenant.Read")]
        [HttpGet]
        public Task<QueryPage<TenantDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetTenantPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetTenantAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Identity.Tenant.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Operations.Database.Tenant.Tenant>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetTenantByIds>().ExecuteAsync(m);

        [NeedPermission("Identity.Tenant.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetTenantExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Tenant.xlsx");


        [NeedPermission("Identity.Tenant.Read")]
        [HttpGet("{id}")]
        public Task<TenantDto?> GetOne([FromRoute] int id) =>
            _operationFactory.New<GetTenant>().ExecuteAsync(id);

        [NeedPermission("Identity.Tenant.Create")]
        [HttpPost]
        public Task<long> Add(TenantAddInDto m) =>
            _operationFactory.New<TenantAdd>().ExecuteAsync(m);

        [NeedPermission("Identity.Tenant.Update")]
        [HttpPut]
        public Task<bool> Update(TenantUpdateInDto m) =>
            _operationFactory.New<TenantUpdate>().ExecuteAsync(m);

        [NeedPermission("Identity.Tenant.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<TenantRemove>().ExecuteAsync(m);

        // ====== Custom Actions:

        [HttpGet("url")]
        public Task<TenantDto?> GetOne([FromQuery] string url) =>
            _operationFactory.New<GetTenantByUrl>().ExecuteAsync(url);

    }
}
