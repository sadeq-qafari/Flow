using System.Collections.Generic;
using System.Threading.Tasks;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;
using Flow.Operations.FormAction;
using Flow.Operations.FormAction.Commands;
using Flow.Operations.FormAction.Dtos;
using Flow.Operations.FormAction.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class FormActionController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public FormActionController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Flow.FormAction.Read")]
        [HttpGet]
        public Task<QueryPage<FormActionDto>?> Get([FromQuery] DbQueryPageInDto m) => 
            _operationFactory.New<GetFormActionPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) => 
            _operationFactory.New<GetFormActionAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Flow.FormAction.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<FormAction>?> GetByIds([FromQuery] DbQueryByIdsInDto m) => 
            _operationFactory.New<GetFormActionByIds>().ExecuteAsync(m);

        [NeedPermission("Flow.FormAction.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetFormActionExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "FormAction.xlsx");
        

        [NeedPermission("Flow.FormAction.Read")]
        [HttpGet("{id}")]
        public Task<FormAction?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetFormAction>().ExecuteAsync(m);

        [NeedPermission("Flow.FormAction.Create")]
        [HttpPost]
        public Task<long> Add(FormActionAddInDto m) =>
            _operationFactory.New<FormActionAdd>().ExecuteAsync(m);

        [NeedPermission("Flow.FormAction.Update")]
        [HttpPut]
        public Task<bool> Update(FormActionUpdateInDto m) =>
            _operationFactory.New<FormActionUpdate>().ExecuteAsync(m);

        [NeedPermission("Flow.FormAction.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<FormActionRemove>().ExecuteAsync(m);
    }
}