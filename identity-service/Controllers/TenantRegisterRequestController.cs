using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Operations.Database.TenantRegisterRequest;
using Identity.Operations.Database.TenantRegisterRequest.Commands;
using Identity.Operations.Database.TenantRegisterRequest.Dtos;
using Identity.Operations.Database.TenantRegisterRequest.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Saanaa.Core.Meteor.Dto;
using Saanaa.Core.AspNetCore.Security;
using Saanaa.Core.Meteor;

namespace Identity.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class TenantRegisterRequestController : ControllerBase
    {
        private readonly OperationFactory _operationFactory;

        public TenantRegisterRequestController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Identity.TenantRegisterRequest.Read")]
        [HttpGet]
        public Task<QueryPage<TenantRegisterRequestDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetTenantRegisterRequestPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetTenantRegisterRequestAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Identity.TenantRegisterRequest.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<TenantRegisterRequest>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetTenantRegisterRequestByIds>().ExecuteAsync(m);

        [NeedPermission("Identity.TenantRegisterRequest.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetTenantRegisterRequestExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "TenantRegisterRequest.xlsx");


        [NeedPermission("Identity.TenantRegisterRequest.Read")]
        [HttpGet("{id}")]
        public Task<TenantRegisterRequest?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetTenantRegisterRequest>().ExecuteAsync(m);

        [HttpPost]
        public Task<long> Add(TenantRegisterRequestAddInDto m)
        {
            m.TenantId = SaanaaTenants.GetTenant(HttpContext)!.Id;
            return _operationFactory.New<TenantRegisterRequestAdd>().ExecuteAsync(m);
        }

        [NeedPermission("Identity.TenantRegisterRequest.Update")]
        [HttpPut]
        public Task<bool> Update(TenantRegisterRequestUpdateInDto m) =>
            _operationFactory.New<TenantRegisterRequestUpdate>().ExecuteAsync(m);

        [NeedPermission("Identity.TenantRegisterRequest.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<TenantRegisterRequestRemove>().ExecuteAsync(m);

        // ============= Custom Actions:

        [NeedPermission("Identity.TenantRegisterRequest.Update")]
        [HttpPut("changeStatus")]
        public Task<TenantRegisterRequestChangeStatusDto> TenantRegisterRequestChangeStatus([FromBody] TenantRegisterRequestChangeStatusInDto m) =>
            _operationFactory.New<TenantRegisterRequestChangeStatus>().ExecuteAsync(m);
    }
}
