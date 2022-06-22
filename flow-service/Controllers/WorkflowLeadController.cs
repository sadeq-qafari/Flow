using System.Collections.Generic;
using System.Threading.Tasks;
using Flow.Operations.WorkflowLead;
using Flow.Operations.WorkflowLead.Commands;
using Flow.Operations.WorkflowLead.Dtos;
using Flow.Operations.WorkflowLead.Queries;
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
    public class WorkflowLeadController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public WorkflowLeadController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Flow.WorkflowLead.Read")]
        [HttpGet]
        public Task<QueryPage<WorkflowLeadDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) => 
            _operationFactory.New<GetWorkflowLeadPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) => 
            _operationFactory.New<GetWorkflowLeadAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Flow.WorkflowLead.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<WorkflowLead>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) => 
            _operationFactory.New<GetWorkflowLeadByIds>().ExecuteAsync(m);

        [NeedPermission("Flow.WorkflowLead.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetWorkflowLeadExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "WorkflowLead.xlsx");
        

        [NeedPermission("Flow.WorkflowLead.Read")]
        [HttpGet("{id}")]
        public Task<WorkflowLead?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetWorkflowLead>().ExecuteAsync(m);

        [NeedPermission("Flow.WorkflowLead.Create")]
        [HttpPost]
        public Task<long> Add(WorkflowLeadAddInDto m) =>
            _operationFactory.New<WorkflowLeadAdd>().ExecuteAsync(m);

        [NeedPermission("Flow.WorkflowLead.Update")]
        [HttpPut]
        public Task<bool> Update(WorkflowLeadUpdateInDto m) =>
            _operationFactory.New<WorkflowLeadUpdate>().ExecuteAsync(m);

        [NeedPermission("Flow.WorkflowLead.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<WorkflowLeadRemove>().ExecuteAsync(m);
    }
}