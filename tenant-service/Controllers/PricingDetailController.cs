using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Saanaa.Core.AspNetCore.Security;
using Saanaa.Core.Meteor.Dto;
using Tenant.Operations.PricingDetail;
using Tenant.Operations.PricingDetail.Commands;
using Tenant.Operations.PricingDetail.Dtos;
using Tenant.Operations.PricingDetail.Queries;

namespace Tenant.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class PricingDetailController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public PricingDetailController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Tenant.PricingDetail.Read")]
        [HttpGet]
        public Task<QueryPage<PricingDetailDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) => 
            _operationFactory.New<GetPricingDetailPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) => 
            _operationFactory.New<GetPricingDetailAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Tenant.PricingDetail.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<PricingDetail>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) => 
            _operationFactory.New<GetPricingDetailByIds>().ExecuteAsync(m);

        [NeedPermission("Tenant.PricingDetail.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetPricingDetailExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "PricingDetail.xlsx");
        

        [NeedPermission("Tenant.PricingDetail.Read")]
        [HttpGet("{id}")]
        public Task<PricingDetail?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetPricingDetail>().ExecuteAsync(m);

        [NeedPermission("Tenant.PricingDetail.Create")]
        [HttpPost]
        public Task<long> Add(PricingDetailAddInDto m) =>
            _operationFactory.New<PricingDetailAdd>().ExecuteAsync(m);

        [NeedPermission("Tenant.PricingDetail.Update")]
        [HttpPut]
        public Task<bool> Update(PricingDetailUpdateInDto m) =>
            _operationFactory.New<PricingDetailUpdate>().ExecuteAsync(m);

        [NeedPermission("Tenant.PricingDetail.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<PricingDetailRemove>().ExecuteAsync(m);
    }
}