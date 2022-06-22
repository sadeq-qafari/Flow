using System.Collections.Generic;
using System.Threading.Tasks;
using Flow.Operations.Workflow;
using Flow.Operations.Workflow.Commands;
using Flow.Operations.Workflow.Dtos;
using Flow.Operations.Workflow.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Saanaa.Core.AspNetCore.Security;
using Saanaa.Core.Meteor.Dto;

namespace Flow.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class WorkflowController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public WorkflowController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Flow.Workflow.Read")]
        [HttpGet]
        public Task<QueryPage<WorkflowDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) => 
            _operationFactory.New<GetWorkflowPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) => 
            _operationFactory.New<GetWorkflowAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Flow.Workflow.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Workflow>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) => 
            _operationFactory.New<GetWorkflowByIds>().ExecuteAsync(m);

        [NeedPermission("Flow.Workflow.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetWorkflowExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Workflow.xlsx");
        

        [NeedPermission("Flow.Workflow.Read")]
        [HttpGet("{id}")]
        public Task<Workflow?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetWorkflow>().ExecuteAsync(m);

        [NeedPermission("Flow.Workflow.Create")]
        [HttpPost]
        public Task<long> Add(WorkflowAddInDto m) =>
            _operationFactory.New<WorkflowAdd>().ExecuteAsync(m);

        [NeedPermission("Flow.Workflow.Update")]
        [HttpPut]
        public Task<bool> Update(WorkflowUpdateInDto m) =>
            _operationFactory.New<WorkflowUpdate>().ExecuteAsync(m);

        [NeedPermission("Flow.Workflow.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<WorkflowRemove>().ExecuteAsync(m);
    }
}