using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Saanaa.Core.AspNetCore.Security;
using Saanaa.Core.Meteor.Dto;
using Tenant.Operations.PricingLog;
using Tenant.Operations.PricingLog.Commands;
using Tenant.Operations.PricingLog.Dtos;
using Tenant.Operations.PricingLog.Queries;

namespace Tenant.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class PricingLogController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public PricingLogController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Tenant.PricingLog.Read")]
        [HttpGet]
        public Task<QueryPage<PricingLogDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) => 
            _operationFactory.New<GetPricingLogPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) => 
            _operationFactory.New<GetPricingLogAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Tenant.PricingLog.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<PricingLog>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) => 
            _operationFactory.New<GetPricingLogByIds>().ExecuteAsync(m);

        [NeedPermission("Tenant.PricingLog.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetPricingLogExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "PricingLog.xlsx");
        

        [NeedPermission("Tenant.PricingLog.Read")]
        [HttpGet("{id}")]
        public Task<PricingLog?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetPricingLog>().ExecuteAsync(m);

        [NeedPermission("Tenant.PricingLog.Create")]
        [HttpPost]
        public Task<long> Add(PricingLogAddInDto m) =>
            _operationFactory.New<PricingLogAdd>().ExecuteAsync(m);

        [NeedPermission("Tenant.PricingLog.Update")]
        [HttpPut]
        public Task<bool> Update(PricingLogUpdateInDto m) =>
            _operationFactory.New<PricingLogUpdate>().ExecuteAsync(m);

        [NeedPermission("Tenant.PricingLog.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<PricingLogRemove>().ExecuteAsync(m);
    }
}