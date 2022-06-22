using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Saanaa.Core.AspNetCore.Security;
using Saanaa.Core.Meteor.Dto;
using Tenant.Operations.PricingDetailTenant;
using Tenant.Operations.PricingDetailTenant.Commands;
using Tenant.Operations.PricingDetailTenant.Dtos;
using Tenant.Operations.PricingDetailTenant.Queries;

namespace Tenant.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class PricingDetailTenantController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public PricingDetailTenantController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Tenant.PricingDetailTenant.Read")]
        [HttpGet]
        public Task<QueryPage<PricingDetailTenantDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) => 
            _operationFactory.New<GetPricingDetailTenantPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) => 
            _operationFactory.New<GetPricingDetailTenantAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Tenant.PricingDetailTenant.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<PricingDetailTenant>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) => 
            _operationFactory.New<GetPricingDetailTenantByIds>().ExecuteAsync(m);

        [NeedPermission("Tenant.PricingDetailTenant.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetPricingDetailTenantExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "PricingDetailTenant.xlsx");
        

        [NeedPermission("Tenant.PricingDetailTenant.Read")]
        [HttpGet("{id}")]
        public Task<PricingDetailTenant?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetPricingDetailTenant>().ExecuteAsync(m);

        [NeedPermission("Tenant.PricingDetailTenant.Create")]
        [HttpPost]
        public Task<long> Add(PricingDetailTenantAddInDto m) =>
            _operationFactory.New<PricingDetailTenantAdd>().ExecuteAsync(m);

        [NeedPermission("Tenant.PricingDetailTenant.Update")]
        [HttpPut]
        public Task<bool> Update(PricingDetailTenantUpdateInDto m) =>
            _operationFactory.New<PricingDetailTenantUpdate>().ExecuteAsync(m);

        [NeedPermission("Tenant.PricingDetailTenant.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<PricingDetailTenantRemove>().ExecuteAsync(m);
    }
}