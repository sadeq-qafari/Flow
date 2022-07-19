using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;
using Tenant.Operations.Role;
using Tenant.Operations.Role.Commands;
using Tenant.Operations.Role.Dto;
using Tenant.Operations.Role.Queries;

namespace Tenant.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public RoleController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Tenant.Role.Read")]
        [HttpGet]
        public Task<QueryPage<RoleDto>?> Get([FromQuery] DbQueryPageInDto m) =>
            _operationFactory.New<GetRolePage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetRoleAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Tenant.Role.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Role>?> GetByIds([FromQuery] DbQueryByIdsInDto m) =>
            _operationFactory.New<GetRoleByIds>().ExecuteAsync(m);

        [NeedPermission("Tenant.Role.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetRoleExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Role.xlsx");


        [NeedPermission("Tenant.Role.Read")]
        [HttpGet("{id}")]
        public Task<Role?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetRole>().ExecuteAsync(m);

        [NeedPermission("Tenant.Role.Create")]
        [HttpPost]
        public Task<long> Add(AddRoleInDto m) =>
            _operationFactory.New<AddRole>().ExecuteAsync(m);

        [NeedPermission("Tenant.Role.Update")]
        [HttpPut]
        public Task<bool> Update(UpdateRoleInDto m) =>
            _operationFactory.New<UpdateRole>().ExecuteAsync(m);

        [NeedPermission("Tenant.Role.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<RemoveRole>().ExecuteAsync(m);
    }
}
