using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Operations.Database.TenantUser;
using Identity.Operations.Database.TenantUser.Commands;
using Identity.Operations.Database.TenantUser.Dtos;
using Identity.Operations.Database.TenantUser.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Saanaa.Core.AspNetCore.Security;
using Saanaa.Core.Meteor.Dto;

namespace Identity.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class TenantUserController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public TenantUserController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Identity.TenantUser.Read")]
        [HttpGet]
        public Task<QueryPage<TenantUserDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetTenantUserPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetTenantUserAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Identity.TenantUser.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<TenantUser>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetTenantUserByIds>().ExecuteAsync(m);

        [NeedPermission("Identity.TenantUser.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetTenantUserExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "TenantUser.xlsx");


        // [NeedPermission("Identity.TenantUser.Read")]
        // [HttpGet("{branchId}/{userId}")]
        // public Task<UserTenantDto?> GetOne([FromRoute] UserBranchDto m) =>
        //     _operationFactory.New<GetUserTenant>().ExecuteAsync(m);

        [NeedPermission("Identity.TenantUser.Create")]
        [HttpPost]
        public Task<long> Add(TenantUserAddInDto m) =>
            _operationFactory.New<TenantUserAdd>().ExecuteAsync(m);

        [NeedPermission("Identity.TenantUser.Update")]
        [HttpPut]
        public Task<bool> Update(TenantUserUpdateInDto m) =>
            _operationFactory.New<TenantUserUpdate>().ExecuteAsync(m);

        [NeedPermission("Identity.TenantUser.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<TenantUserRemove>().ExecuteAsync(m);

        // =================== Custom Actions:

        [NeedPermission]
        [HttpGet("tenants")]
        public Task<IEnumerable<UserTenantDto>?> GetTenants() =>
            _operationFactory.New<GetAllUserTenants>().ExecuteAsync(HttpContext.UserInfo()!.UserName);
    }
}
