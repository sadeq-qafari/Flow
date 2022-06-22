using System.Collections.Generic;
using System.Threading.Tasks;
using Flow.Operations.FormPermission;
using Flow.Operations.FormPermission.Commands;
using Flow.Operations.FormPermission.Dtos;
using Flow.Operations.FormPermission.Queries;
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
    public class FormPermissionController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public FormPermissionController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Flow.FormPermission.Read")]
        [HttpGet]
        public Task<QueryPage<FormPermissionDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetFormPermissionPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetFormPermissionAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Flow.FormPermission.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<FormPermission>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetFormPermissionByIds>().ExecuteAsync(m);

        [NeedPermission("Flow.FormPermission.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetFormPermissionExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "FormPermission.xlsx");


        [NeedPermission("Flow.FormPermission.Read")]
        [HttpGet("{id}")]
        public Task<FormPermission?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetFormPermission>().ExecuteAsync(m);

        [NeedPermission("Flow.FormPermission.Create")]
        [HttpPost]
        public Task<long> Add(FormPermissionAddInDto m) =>
            _operationFactory.New<FormPermissionAdd>().ExecuteAsync(m);

        [NeedPermission("Flow.FormPermission.Update")]
        [HttpPut]
        public Task<bool> Update(FormPermissionUpdateInDto m) =>
            _operationFactory.New<FormPermissionUpdate>().ExecuteAsync(m);

        [NeedPermission("Flow.FormPermission.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<FormPermissionRemove>().ExecuteAsync(m);
    }
}
