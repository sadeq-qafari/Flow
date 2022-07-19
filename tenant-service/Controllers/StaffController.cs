using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;
using Tenant.Operations.Staff;
using Tenant.Operations.Staff.Commands;
using Tenant.Operations.Staff.Dtos;
using Tenant.Operations.Staff.Queries;

namespace Tenant.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class StaffController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public StaffController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Tenant.Staff.Read")]
        [HttpGet]
        public Task<QueryPage<StaffDto>?> Get([FromQuery] DbQueryPageInDto m) => 
            _operationFactory.New<GetStaffPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) => 
            _operationFactory.New<GetStaffAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Tenant.Staff.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Staff>?> GetByIds([FromQuery] DbQueryByIdsInDto m) => 
            _operationFactory.New<GetStaffByIds>().ExecuteAsync(m);

        [NeedPermission("Tenant.Staff.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetStaffExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Staff.xlsx");
        

        [NeedPermission("Tenant.Staff.Read")]
        [HttpGet("{id}")]
        public Task<Staff?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetStaff>().ExecuteAsync(m);

        [NeedPermission("Tenant.Staff.Create")]
        [HttpPost]
        public Task<long> Add(StaffAddInDto m) =>
            _operationFactory.New<StaffAdd>().ExecuteAsync(m);

        [NeedPermission("Tenant.Staff.Update")]
        [HttpPut]
        public Task<bool> Update(StaffUpdateInDto m) =>
            _operationFactory.New<StaffUpdate>().ExecuteAsync(m);

        [NeedPermission("Tenant.Staff.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<StaffRemove>().ExecuteAsync(m);
    }
}