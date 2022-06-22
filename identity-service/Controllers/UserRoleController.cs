using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Operations.Database.UserRole;
using Identity.Operations.Database.UserRole.Commands;
using Identity.Operations.Database.UserRole.Dtos;
using Identity.Operations.Database.UserRole.Queries;
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
    public class UserRoleController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public UserRoleController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Identity.UserRole.Read")]
        [HttpGet]
        public Task<QueryPage<UserRoleDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetUserRolePage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetUserRoleAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Identity.UserRole.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<UserRole>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetUserRoleByIds>().ExecuteAsync(m);

        [NeedPermission("Identity.UserRole.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetUserRoleExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "UserRole.xlsx");


        [NeedPermission("Identity.UserRole.Read")]
        [HttpGet("{id}")]
        public Task<UserRole?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetUserRole>().ExecuteAsync(m);

        [NeedPermission("Identity.UserRole.Create")]
        [HttpPost]
        public Task<long> Add(UserRoleAddInDto m) =>
            _operationFactory.New<UserRoleAdd>().ExecuteAsync(m);

        [NeedPermission("Identity.UserRole.Update")]
        [HttpPut]
        public Task<bool> Update(UserRoleUpdateInDto m) =>
            _operationFactory.New<UserRoleUpdate>().ExecuteAsync(m);

        [NeedPermission("Identity.UserRole.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<UserRoleRemove>().ExecuteAsync(m);
    }
}
