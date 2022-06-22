using System.Collections.Generic;
using System.Threading.Tasks;
using Flow.Operations.FormProperty;
using Flow.Operations.FormProperty.Commands;
using Flow.Operations.FormProperty.Dtos;
using Flow.Operations.FormProperty.Queries;
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
    public class FormPropertyController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public FormPropertyController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Flow.FormProperty.Read")]
        [HttpGet]
        public Task<QueryPage<FormPropertyDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) => 
            _operationFactory.New<GetFormPropertyPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) => 
            _operationFactory.New<GetFormPropertyAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Flow.FormProperty.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<FormProperty>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) => 
            _operationFactory.New<GetFormPropertyByIds>().ExecuteAsync(m);

        [NeedPermission("Flow.FormProperty.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetFormPropertyExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "FormProperty.xlsx");
        

        [NeedPermission("Flow.FormProperty.Read")]
        [HttpGet("{id}")]
        public Task<FormProperty?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetFormProperty>().ExecuteAsync(m);

        [NeedPermission("Flow.FormProperty.Create")]
        [HttpPost]
        public Task<long> Add(FormPropertyAddInDto m) =>
            _operationFactory.New<FormPropertyAdd>().ExecuteAsync(m);

        [NeedPermission("Flow.FormProperty.Update")]
        [HttpPut]
        public Task<bool> Update(FormPropertyUpdateInDto m) =>
            _operationFactory.New<FormPropertyUpdate>().ExecuteAsync(m);

        [NeedPermission("Flow.FormProperty.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<FormPropertyRemove>().ExecuteAsync(m);
    }
}