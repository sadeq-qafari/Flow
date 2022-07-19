using System.Collections.Generic;
using System.Threading.Tasks;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;
using Flow.Operations.WorkflowStep;
using Flow.Operations.WorkflowStep.Commands;
using Flow.Operations.WorkflowStep.Dtos;
using Flow.Operations.WorkflowStep.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class WorkflowStepController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public WorkflowStepController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Flow.WorkflowStep.Read")]
        [HttpGet]
        public Task<QueryPage<WorkflowStepDto>?> Get([FromQuery] DbQueryPageInDto m) => 
            _operationFactory.New<GetWorkflowStepPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) => 
            _operationFactory.New<GetWorkflowStepAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Flow.WorkflowStep.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<WorkflowStep>?> GetByIds([FromQuery] DbQueryByIdsInDto m) => 
            _operationFactory.New<GetWorkflowStepByIds>().ExecuteAsync(m);

        [NeedPermission("Flow.WorkflowStep.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetWorkflowStepExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "WorkflowStep.xlsx");
        

        [NeedPermission("Flow.WorkflowStep.Read")]
        [HttpGet("{id}")]
        public Task<WorkflowStep?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetWorkflowStep>().ExecuteAsync(m);

        [NeedPermission("Flow.WorkflowStep.Create")]
        [HttpPost]
        public Task<long> Add(WorkflowStepAddInDto m) =>
            _operationFactory.New<WorkflowStepAdd>().ExecuteAsync(m);

        [NeedPermission("Flow.WorkflowStep.Update")]
        [HttpPut]
        public Task<bool> Update(WorkflowStepUpdateInDto m) =>
            _operationFactory.New<WorkflowStepUpdate>().ExecuteAsync(m);

        [NeedPermission("Flow.WorkflowStep.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<WorkflowStepRemove>().ExecuteAsync(m);
    }
}