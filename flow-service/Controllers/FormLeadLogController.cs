using System.Collections.Generic;
using System.Threading.Tasks;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;
using Flow.Operations.FormLeadLog;
using Flow.Operations.FormLeadLog.Commands;
using Flow.Operations.FormLeadLog.Dtos;
using Flow.Operations.FormLeadLog.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class FormLeadLogController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public FormLeadLogController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Flow.FormLeadLog.Read")]
        [HttpGet]
        public Task<QueryPage<FormLeadLogDto>?> Get([FromQuery] DbQueryPageInDto m) => 
            _operationFactory.New<GetFormLeadLogPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) => 
            _operationFactory.New<GetFormLeadLogAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Flow.FormLeadLog.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<FormLeadLog>?> GetByIds([FromQuery] DbQueryByIdsInDto m) => 
            _operationFactory.New<GetFormLeadLogByIds>().ExecuteAsync(m);

        [NeedPermission("Flow.FormLeadLog.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetFormLeadLogExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "FormLeadLog.xlsx");
        

        [NeedPermission("Flow.FormLeadLog.Read")]
        [HttpGet("{id}")]
        public Task<FormLeadLog?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetFormLeadLog>().ExecuteAsync(m);

        [NeedPermission("Flow.FormLeadLog.Create")]
        [HttpPost]
        public Task<long> Add(FormLeadLogAddInDto m) =>
            _operationFactory.New<FormLeadLogAdd>().ExecuteAsync(m);

        [NeedPermission("Flow.FormLeadLog.Update")]
        [HttpPut]
        public Task<bool> Update(FormLeadLogUpdateInDto m) =>
            _operationFactory.New<FormLeadLogUpdate>().ExecuteAsync(m);

        [NeedPermission("Flow.FormLeadLog.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<FormLeadLogRemove>().ExecuteAsync(m);
    }
}