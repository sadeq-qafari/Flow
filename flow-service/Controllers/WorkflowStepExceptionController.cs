using System.Collections.Generic;
using System.Threading.Tasks;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;
using Flow.Operations.WorkflowStepException;
using Flow.Operations.WorkflowStepException.Commands;
using Flow.Operations.WorkflowStepException.Dtos;
using Flow.Operations.WorkflowStepException.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class WorkflowStepExceptionController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public WorkflowStepExceptionController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Flow.WorkflowStepException.Read")]
        [HttpGet]
        public Task<QueryPage<WorkflowStepExceptionDto>?> Get([FromQuery] DbQueryPageInDto m) => 
            _operationFactory.New<GetWorkflowStepExceptionPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) => 
            _operationFactory.New<GetWorkflowStepExceptionAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Flow.WorkflowStepException.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<WorkflowStepException>?> GetByIds([FromQuery] DbQueryByIdsInDto m) => 
            _operationFactory.New<GetWorkflowStepExceptionByIds>().ExecuteAsync(m);

        [NeedPermission("Flow.WorkflowStepException.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetWorkflowStepExceptionExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "WorkflowStepException.xlsx");
        

        [NeedPermission("Flow.WorkflowStepException.Read")]
        [HttpGet("{id}")]
        public Task<WorkflowStepException?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetWorkflowStepException>().ExecuteAsync(m);

        [NeedPermission("Flow.WorkflowStepException.Create")]
        [HttpPost]
        public Task<long> Add(WorkflowStepExceptionAddInDto m) =>
            _operationFactory.New<WorkflowStepExceptionAdd>().ExecuteAsync(m);

        [NeedPermission("Flow.WorkflowStepException.Update")]
        [HttpPut]
        public Task<bool> Update(WorkflowStepExceptionUpdateInDto m) =>
            _operationFactory.New<WorkflowStepExceptionUpdate>().ExecuteAsync(m);

        [NeedPermission("Flow.WorkflowStepException.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<WorkflowStepExceptionRemove>().ExecuteAsync(m);
    }
}