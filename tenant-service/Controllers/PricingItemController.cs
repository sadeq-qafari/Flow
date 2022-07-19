using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;
using Tenant.Operations.PricingItem;
using Tenant.Operations.PricingItem.Commands;
using Tenant.Operations.PricingItem.Dtos;
using Tenant.Operations.PricingItem.Queries;

namespace Tenant.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class PricingItemController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public PricingItemController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Tenant.PricingItem.Read")]
        [HttpGet]
        public Task<QueryPage<PricingItemDto>?> Get([FromQuery] DbQueryPageInDto m) => 
            _operationFactory.New<GetPricingItemPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) => 
            _operationFactory.New<GetPricingItemAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Tenant.PricingItem.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<PricingItem>?> GetByIds([FromQuery] DbQueryByIdsInDto m) => 
            _operationFactory.New<GetPricingItemByIds>().ExecuteAsync(m);

        [NeedPermission("Tenant.PricingItem.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetPricingItemExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "PricingItem.xlsx");
        

        [NeedPermission("Tenant.PricingItem.Read")]
        [HttpGet("{id}")]
        public Task<PricingItem?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetPricingItem>().ExecuteAsync(m);

        [NeedPermission("Tenant.PricingItem.Create")]
        [HttpPost]
        public Task<long> Add(PricingItemAddInDto m) =>
            _operationFactory.New<PricingItemAdd>().ExecuteAsync(m);

        [NeedPermission("Tenant.PricingItem.Update")]
        [HttpPut]
        public Task<bool> Update(PricingItemUpdateInDto m) =>
            _operationFactory.New<PricingItemUpdate>().ExecuteAsync(m);

        [NeedPermission("Tenant.PricingItem.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<PricingItemRemove>().ExecuteAsync(m);
    }
}