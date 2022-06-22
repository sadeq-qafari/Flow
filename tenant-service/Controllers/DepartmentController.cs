using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Saanaa.Core.AspNetCore.Security;
using Saanaa.Core.Meteor.Dto;
using Tenant.Operations.Department;
using Tenant.Operations.Department.Commands;
using Tenant.Operations.Department.Dto;
using Tenant.Operations.Department.Queries;

namespace Tenant.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public DepartmentController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Tenant.Department.Read")]
        [HttpGet]
        public Task<QueryPage<DepartmentDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetDepartmentPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetDepartmentAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Tenant.Department.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Department>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetDepartmentByIds>().ExecuteAsync(m);

        [NeedPermission("Tenant.Department.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetDepartmentExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Department.xlsx");


        [NeedPermission("Tenant.Department.Read")]
        [HttpGet("{id}")]
        public Task<Department?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetDepartment>().ExecuteAsync(m);

        [NeedPermission("Tenant.Department.Create")]
        [HttpPost]
        public Task<long> Add(AddDepartmentInDto m) =>
            _operationFactory.New<AddDepartment>().ExecuteAsync(m);

        [NeedPermission("Tenant.Department.Update")]
        [HttpPut]
        public Task<bool> Update(UpdateDepartmentInDto m) =>
            _operationFactory.New<UpdateDepartment>().ExecuteAsync(m);

        [NeedPermission("Tenant.Department.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<RemoveDepartment>().ExecuteAsync(m);
    }
}
