using System.Collections.Generic;
using System.Threading.Tasks;
using Flow.Operations.WorkflowTransaction;
using Flow.Operations.WorkflowTransaction.Commands;
using Flow.Operations.WorkflowTransaction.Dtos;
using Flow.Operations.WorkflowTransaction.Queries;
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
    public class WorkflowTransactionController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public WorkflowTransactionController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Flow.WorkflowTransaction.Read")]
        [HttpGet]
        public Task<QueryPage<WorkflowTransactionDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) => 
            _operationFactory.New<GetWorkflowTransactionPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) => 
            _operationFactory.New<GetWorkflowTransactionAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Flow.WorkflowTransaction.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<WorkflowTransaction>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) => 
            _operationFactory.New<GetWorkflowTransactionByIds>().ExecuteAsync(m);

        [NeedPermission("Flow.WorkflowTransaction.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetWorkflowTransactionExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "WorkflowTransaction.xlsx");
        

        [NeedPermission("Flow.WorkflowTransaction.Read")]
        [HttpGet("{id}")]
        public Task<WorkflowTransaction?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetWorkflowTransaction>().ExecuteAsync(m);

        [NeedPermission("Flow.WorkflowTransaction.Create")]
        [HttpPost]
        public Task<long> Add(WorkflowTransactionAddInDto m) =>
            _operationFactory.New<WorkflowTransactionAdd>().ExecuteAsync(m);

        [NeedPermission("Flow.WorkflowTransaction.Update")]
        [HttpPut]
        public Task<bool> Update(WorkflowTransactionUpdateInDto m) =>
            _operationFactory.New<WorkflowTransactionUpdate>().ExecuteAsync(m);

        [NeedPermission("Flow.WorkflowTransaction.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<WorkflowTransactionRemove>().ExecuteAsync(m);
    }
}