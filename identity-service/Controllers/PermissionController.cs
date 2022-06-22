using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Operations.Database.Permission;
using Identity.Operations.Database.Permission.Commands;
using Identity.Operations.Database.Permission.Dtos;
using Identity.Operations.Database.Permission.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Saanaa.Core.AspNetCore.Operations.Db.UserPermissions.Dto;
using Saanaa.Core.AspNetCore.Security;
using Saanaa.Core.Meteor.Dto;

namespace Identity.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class PermissionController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public PermissionController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Identity.Permission.Read")]
        [HttpGet]
        public Task<QueryPage<PermissionDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetPermissionPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetPermissionAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Identity.Permission.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Permission>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetPermissionByIds>().ExecuteAsync(m);

        [NeedPermission("Identity.Permission.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetPermissionExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Permission.xlsx");


        [NeedPermission("Identity.Permission.Read")]
        [HttpGet("{id}")]
        public Task<Permission?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetPermission>().ExecuteAsync(m);

        [NeedPermission("Identity.Permission.Create")]
        [HttpPost]
        public Task<long> Add(PermissionAddInDto m) =>
            _operationFactory.New<PermissionAdd>().ExecuteAsync(m);

        [NeedPermission("Identity.Permission.Update")]
        [HttpPut]
        public Task<bool> Update(PermissionUpdateInDto m) =>
            _operationFactory.New<PermissionUpdate>().ExecuteAsync(m);

        [NeedPermission("Identity.Permission.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<PermissionRemove>().ExecuteAsync(m);

        // ============= Custom Actions:

        [HttpGet("all")]
        public Task<PermissionStore?> GetAll() =>
            _operationFactory.New<GetPermissions>().ExecuteAsync();
    }
}
