using System.Collections.Generic;
using System.Threading.Tasks;
using Core.AspNetCore.Operations.Db.Identity.Dto;
using Identity.Operations.Database.User;
using Identity.Operations.Database.User.Commands;
using Identity.Operations.Database.User.Dtos;
using Identity.Operations.Database.User.Queries;
using Identity.Operations.Logic.Dto;
using Identity.Operations.Logic.GetClaimsFromToken;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;
using GetUserPermissionsInDto = Identity.Operations.Database.User.Dtos.GetUserPermissionsInDto;

namespace Identity.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly OperationFactory _operationFactory;

        public UserController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Identity.User.Read")]
        [HttpGet]
        public Task<QueryPage<UserDto>?> Get([FromQuery] DbQueryPageInDto m) =>
            _operationFactory.New<GetUserPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetUserAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Identity.User.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<User>?> GetByIds([FromQuery] DbQueryByIdsInDto m) =>
            _operationFactory.New<GetUserByIds>().ExecuteAsync(m);

        [NeedPermission("Identity.User.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetUserExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "User.xlsx");

        [NeedPermission("Identity.User.Create")]
        [HttpPost]
        public Task<long> Add(UserAddInDto m) =>
            _operationFactory.New<UserAdd>().ExecuteAsync(m);

        [NeedPermission("Identity.User.Update")]
        [HttpPut]
        public Task<bool> Update(UserUpdateInDto m) =>
            _operationFactory.New<UserUpdate>().ExecuteAsync(m);

        [NeedPermission("Identity.User.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<UserRemove>().ExecuteAsync(m);

        // ============= Custom Actions :

        [Authorize("backend")]
        [HttpGet("permissions")]
        public Task<PermissionStore?> GetUserPermissions([FromQuery] GetUserPermissionsInDto m) =>
            _operationFactory.New<GetUserPermissions>().ExecuteAsync(m);

        [Authorize]
        [HttpGet("info")]
        public Task<UserInfoDto?> GetUserInfo()
        {
            var accessToken = (Request.Headers[HeaderNames.Authorization]).ToString().Substring(7);
            return _operationFactory.New<GetUserInfo>().ExecuteAsync(accessToken);
        }
    }
}
