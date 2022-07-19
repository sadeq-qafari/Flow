using System.Collections.Generic;
using System.Threading.Tasks;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;
using Flow.Operations.FormLead;
using Flow.Operations.FormLead.Commands;
using Flow.Operations.FormLead.Dtos;
using Flow.Operations.FormLead.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class FormLeadController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public FormLeadController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Flow.FormLead.Read")]
        [HttpGet]
        public Task<QueryPage<FormLeadDto>?> Get([FromQuery] DbQueryPageInDto m) => 
            _operationFactory.New<GetFormLeadPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) => 
            _operationFactory.New<GetFormLeadAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Flow.FormLead.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<FormLead>?> GetByIds([FromQuery] DbQueryByIdsInDto m) => 
            _operationFactory.New<GetFormLeadByIds>().ExecuteAsync(m);

        [NeedPermission("Flow.FormLead.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetFormLeadExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "FormLead.xlsx");
        

        [NeedPermission("Flow.FormLead.Read")]
        [HttpGet("{id}")]
        public Task<FormLead?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetFormLead>().ExecuteAsync(m);

        [NeedPermission("Flow.FormLead.Create")]
        [HttpPost]
        public Task<long> Add(FormLeadAddInDto m) =>
            _operationFactory.New<FormLeadAdd>().ExecuteAsync(m);

        [NeedPermission("Flow.FormLead.Update")]
        [HttpPut]
        public Task<bool> Update(FormLeadUpdateInDto m) =>
            _operationFactory.New<FormLeadUpdate>().ExecuteAsync(m);

        [NeedPermission("Flow.FormLead.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<FormLeadRemove>().ExecuteAsync(m);
    }
}