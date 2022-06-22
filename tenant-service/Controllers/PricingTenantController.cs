using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Meteor.Utils;
using Microsoft.AspNetCore.Mvc;
using Saanaa.Core.AspNetCore.Operations.Db.Payment.Dto;
using Saanaa.Core.AspNetCore.Security;
using Saanaa.Core.Meteor.Dto;
using Tenant.Operations.PricingTenant;
using Tenant.Operations.PricingTenant.Commands;
using Tenant.Operations.PricingTenant.Dtos;
using Tenant.Operations.PricingTenant.Queries;

namespace Tenant.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class PricingTenantController : ControllerBase
    {
        private readonly OperationFactory _operationFactory;

        public PricingTenantController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Tenant.PricingTenant.Read")]
        [HttpGet]
        public Task<QueryPage<PricingTenantDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetPricingTenantPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetPricingTenantAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Tenant.PricingTenant.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<PricingTenant>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetPricingTenantByIds>().ExecuteAsync(m);

        [NeedPermission("Tenant.PricingTenant.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetPricingTenantExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "PricingTenant.xlsx");


        [NeedPermission("Tenant.PricingTenant.Read")]
        [HttpGet("{id}")]
        public Task<PricingTenant?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetPricingTenant>().ExecuteAsync(m);

        [NeedPermission("Tenant.PricingTenant.Create")]
        [HttpPost]
        public Task<long> Add(PricingTenantAddInDto m) =>
            _operationFactory.New<PricingTenantAdd>().ExecuteAsync(m);

        [NeedPermission("Tenant.PricingTenant.Update")]
        [HttpPut]
        public Task<bool> Update(PricingTenantUpdateInDto m) =>
            _operationFactory.New<PricingTenantUpdate>().ExecuteAsync(m);

        [NeedPermission("Tenant.PricingTenant.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<PricingTenantRemove>().ExecuteAsync(m);

        // ============= Custom Actions:

        [NeedPermission(Policies = "backend")]
        [HttpPost("settle")]
        public async Task<bool?> SettleOrderFlight([FromBody] object m)
        {
            var jsonModel = m.ToJson();
            var model = jsonModel.FromJson<PaymentResult>();
            return await _operationFactory.New<PricingTenantSettle>().ExecuteAsync(model);
        }
    }
}
