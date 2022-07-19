using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Operations.Database.RolePermission;
using Identity.Operations.Database.RolePermission.Commands;
using Identity.Operations.Database.RolePermission.Dtos;
using Identity.Operations.Database.RolePermission.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;

namespace Identity.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class RolePermissionController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public RolePermissionController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Identity.RolePermission.Read")]
        [HttpGet]
        public Task<QueryPage<RolePermissionDto>?> Get([FromQuery] DbQueryPageInDto m) =>
            _operationFactory.New<GetRolePermissionPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetRolePermissionAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Identity.RolePermission.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<RolePermission>?> GetByIds([FromQuery] DbQueryByIdsInDto m) =>
            _operationFactory.New<GetRolePermissionByIds>().ExecuteAsync(m);

        [NeedPermission("Identity.RolePermission.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetRolePermissionExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "RolePermission.xlsx");


        [NeedPermission("Identity.RolePermission.Read")]
        [HttpGet("{id}")]
        public Task<RolePermission?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetRolePermission>().ExecuteAsync(m);

        [NeedPermission("Identity.RolePermission.Create")]
        [HttpPost]
        public Task<long> Add(RolePermissionAddInDto m) =>
            _operationFactory.New<RolePermissionAdd>().ExecuteAsync(m);

        [NeedPermission("Identity.RolePermission.Update")]
        [HttpPut]
        public Task<bool> Update(RolePermissionUpdateInDto m) =>
            _operationFactory.New<RolePermissionUpdate>().ExecuteAsync(m);

        [NeedPermission("Identity.RolePermission.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<RolePermissionRemove>().ExecuteAsync(m);

        // ========= Custom Actions:

        [NeedPermission("Identity.RolePermission.Read")]
        [HttpGet("checkList/{id}")]
        public Task<PermissionCheckList?> GetAll([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetRolePermissions>().ExecuteAsync(m);

        // [NeedPermission("Identity.RolePermission.Read")]
        // [HttpPost("merge")]
        // public Task<bool> RolePermissionMerge([FromBody] RolePermissionMergeInDto m) =>
        //     _operationFactory.New<RolePermissionMerge>().ExecuteAsync(m);

    }
}
