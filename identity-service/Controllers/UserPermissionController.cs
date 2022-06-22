using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Operations.Database.UserPermission;
using Identity.Operations.Database.UserPermission.Commands;
using Identity.Operations.Database.UserPermission.Dtos;
using Identity.Operations.Database.UserPermission.Queries;
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
    public class UserPermissionController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public UserPermissionController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Identity.UserPermission.Read")]
        [HttpGet]
        public Task<QueryPage<UserPermissionDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetUserPermissionPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetUserPermissionAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Identity.UserPermission.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<UserPermission>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetUserPermissionByIds>().ExecuteAsync(m);

        [NeedPermission("Identity.UserPermission.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetUserPermissionExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "UserPermission.xlsx");


        [NeedPermission("Identity.UserPermission.Read")]
        [HttpGet("{id}")]
        public Task<UserPermission?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetUserPermission>().ExecuteAsync(m);

        [NeedPermission("Identity.UserPermission.Create")]
        [HttpPost]
        public Task<long> Add(UserPermissionAddInDto m) =>
            _operationFactory.New<UserPermissionAdd>().ExecuteAsync(m);

        [NeedPermission("Identity.UserPermission.Update")]
        [HttpPut]
        public Task<bool> Update(UserPermissionUpdateInDto m) =>
            _operationFactory.New<UserPermissionUpdate>().ExecuteAsync(m);

        [NeedPermission("Identity.UserPermission.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<UserPermissionRemove>().ExecuteAsync(m);
    }
}
