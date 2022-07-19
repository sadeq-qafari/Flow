using System.Collections.Generic;
using System.Threading.Tasks;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;
using Flow.Operations.LookupItem;
using Flow.Operations.LookupItem.Commands;
using Flow.Operations.LookupItem.Dtos;
using Flow.Operations.LookupItem.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class LookupItemController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public LookupItemController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Flow.LookupItem.Read")]
        [HttpGet]
        public Task<QueryPage<LookupItemDto>?> Get([FromQuery] DbQueryPageInDto m) => 
            _operationFactory.New<GetLookupItemPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) => 
            _operationFactory.New<GetLookupItemAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Flow.LookupItem.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<LookupItem>?> GetByIds([FromQuery] DbQueryByIdsInDto m) => 
            _operationFactory.New<GetLookupItemByIds>().ExecuteAsync(m);

        [NeedPermission("Flow.LookupItem.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetLookupItemExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "LookupItem.xlsx");
        

        [NeedPermission("Flow.LookupItem.Read")]
        [HttpGet("{id}")]
        public Task<LookupItem?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetLookupItem>().ExecuteAsync(m);

        [NeedPermission("Flow.LookupItem.Create")]
        [HttpPost]
        public Task<long> Add(LookupItemAddInDto m) =>
            _operationFactory.New<LookupItemAdd>().ExecuteAsync(m);

        [NeedPermission("Flow.LookupItem.Update")]
        [HttpPut]
        public Task<bool> Update(LookupItemUpdateInDto m) =>
            _operationFactory.New<LookupItemUpdate>().ExecuteAsync(m);

        [NeedPermission("Flow.LookupItem.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<LookupItemRemove>().ExecuteAsync(m);
    }
}