using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Operations.Database.Role;
using Identity.Operations.Database.Role.Commands;
using Identity.Operations.Database.Role.Dtos;
using Identity.Operations.Database.Role.Queries;
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
    public class RoleController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public RoleController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Identity.Role.Read")]
        [HttpGet]
        public Task<QueryPage<RoleDto>?> Get([FromQuery] DbQueryPageInDto m) =>
            _operationFactory.New<GetRolePage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetRoleAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Identity.Role.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Role>?> GetByIds([FromQuery] DbQueryByIdsInDto m) =>
            _operationFactory.New<GetRoleByIds>().ExecuteAsync(m);

        [NeedPermission("Identity.Role.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetRoleExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Role.xlsx");


        [NeedPermission("Identity.Role.Read")]
        [HttpGet("{id}")]
        public Task<RoleDto?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetRole>().ExecuteAsync(m);

        [NeedPermission("Identity.Role.Create")]
        [HttpPost]
        public Task<long> Add(RoleAddInDto m) =>
            _operationFactory.New<RoleAdd>().ExecuteAsync(m);

        [NeedPermission("Identity.Role.Update")]
        [HttpPut]
        public Task<bool> Update(RoleUpdateInDto m) =>
            _operationFactory.New<RoleUpdate>().ExecuteAsync(m);

        [NeedPermission("Identity.Role.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<RoleRemove>().ExecuteAsync(m);
    }
}
