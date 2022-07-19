using System.Collections.Generic;
using System.Threading.Tasks;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;
using Flow.Operations.FormLeadData;
using Flow.Operations.FormLeadData.Commands;
using Flow.Operations.FormLeadData.Dtos;
using Flow.Operations.FormLeadData.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class FormLeadDataController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public FormLeadDataController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Flow.FormLeadData.Read")]
        [HttpGet]
        public Task<QueryPage<FormLeadDataDto>?> Get([FromQuery] DbQueryPageInDto m) => 
            _operationFactory.New<GetFormLeadDataPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) => 
            _operationFactory.New<GetFormLeadDataAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Flow.FormLeadData.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<FormLeadData>?> GetByIds([FromQuery] DbQueryByIdsInDto m) => 
            _operationFactory.New<GetFormLeadDataByIds>().ExecuteAsync(m);

        [NeedPermission("Flow.FormLeadData.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetFormLeadDataExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "FormLeadData.xlsx");
        

        [NeedPermission("Flow.FormLeadData.Read")]
        [HttpGet("{id}")]
        public Task<FormLeadData?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetFormLeadData>().ExecuteAsync(m);

        [NeedPermission("Flow.FormLeadData.Create")]
        [HttpPost]
        public Task<long> Add(FormLeadDataAddInDto m) =>
            _operationFactory.New<FormLeadDataAdd>().ExecuteAsync(m);

        [NeedPermission("Flow.FormLeadData.Update")]
        [HttpPut]
        public Task<bool> Update(FormLeadDataUpdateInDto m) =>
            _operationFactory.New<FormLeadDataUpdate>().ExecuteAsync(m);

        [NeedPermission("Flow.FormLeadData.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<FormLeadDataRemove>().ExecuteAsync(m);
    }
}