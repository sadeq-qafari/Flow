using System.Collections.Generic;
using System.Threading.Tasks;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;
using Flow.Operations.Element;
using Flow.Operations.Element.Commands;
using Flow.Operations.Element.Dtos;
using Flow.Operations.Element.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class ElementController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public ElementController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Flow.Element.Read")]
        [HttpGet]
        public Task<QueryPage<ElementDto>?> Get([FromQuery] DbQueryPageInDto m) => 
            _operationFactory.New<GetElementPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) => 
            _operationFactory.New<GetElementAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Flow.Element.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Element>?> GetByIds([FromQuery] DbQueryByIdsInDto m) => 
            _operationFactory.New<GetElementByIds>().ExecuteAsync(m);

        [NeedPermission("Flow.Element.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetElementExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Element.xlsx");
        

        [NeedPermission("Flow.Element.Read")]
        [HttpGet("{id}")]
        public Task<Element?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetElement>().ExecuteAsync(m);

        [NeedPermission("Flow.Element.Create")]
        [HttpPost]
        public Task<long> Add(ElementAddInDto m) =>
            _operationFactory.New<ElementAdd>().ExecuteAsync(m);

        [NeedPermission("Flow.Element.Update")]
        [HttpPut]
        public Task<bool> Update(ElementUpdateInDto m) =>
            _operationFactory.New<ElementUpdate>().ExecuteAsync(m);

        [NeedPermission("Flow.Element.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<ElementRemove>().ExecuteAsync(m);

        [HttpGet("list")]
        public Task<IEnumerable<ElementsDto>?> GetElements() =>
            _operationFactory.New<GetElements>().ExecuteAsync();
    }
}