using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Saanaa.Core.AspNetCore.Security;
using Saanaa.Core.Meteor.Dto;
using Tenant.Operations.Pricing;
using Tenant.Operations.Pricing.Commands;
using Tenant.Operations.Pricing.Dtos;
using Tenant.Operations.Pricing.Queries;

namespace Tenant.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class PricingController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public PricingController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Tenant.Pricing.Read")]
        [HttpGet]
        public Task<QueryPage<PricingDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetPricingPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetPricingAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Tenant.Pricing.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Pricing>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetPricingByIds>().ExecuteAsync(m);

        [NeedPermission("Tenant.Pricing.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetPricingExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Pricing.xlsx");


        [NeedPermission("Tenant.Pricing.Read")]
        [HttpGet("{id}")]
        public Task<Pricing?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetPricing>().ExecuteAsync(m);

        [NeedPermission("Tenant.Pricing.Create")]
        [HttpPost]
        public Task<long> Add(PricingAddInDto m) =>
            _operationFactory.New<PricingAdd>().ExecuteAsync(m);

        [NeedPermission("Tenant.Pricing.Update")]
        [HttpPut]
        public Task<bool> Update(PricingUpdateInDto m) =>
            _operationFactory.New<PricingUpdate>().ExecuteAsync(m);

        [NeedPermission("Tenant.Pricing.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<PricingRemove>().ExecuteAsync(m);

        // =========== Custom Actions:

        [HttpGet("application/{appId}")]
        public Task<IEnumerable<Pricing>?> GetOne([FromRoute] int appId) =>
            _operationFactory.New<GetPricings>().ExecuteAsync(appId);
    }
}
