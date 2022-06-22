using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Saanaa.Core.AspNetCore.Security;
using Saanaa.Core.Meteor.Dto;
using Tenant.Operations.Dashboard;
using Tenant.Operations.Dashboard.Commands;
using Tenant.Operations.Dashboard.Dtos;
using Tenant.Operations.Dashboard.Queries;

namespace Tenant.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly OperationFactory _operationFactory;

        public DashboardController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Tenant.Dashboard.Read")]
        [HttpGet]
        public Task<QueryPage<DashboardDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetDashboardPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetDashboardAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Tenant.Dashboard.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Dashboard>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetDashboardByIds>().ExecuteAsync(m);

        [NeedPermission("Tenant.Dashboard.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetDashboardExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Dashboard.xlsx");


        [NeedPermission("Tenant.Dashboard.Read")]
        [HttpGet("{id}")]
        public Task<Dashboard?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetDashboard>().ExecuteAsync(m);

        [NeedPermission]
        [HttpPost]
        public Task<long> Add(DashboardAddInDto m) =>
            _operationFactory.New<DashboardAdd>().ExecuteAsync(m);

        [NeedPermission("Tenant.Dashboard.Update")]
        [HttpPut]
        public Task<bool> Update(DashboardUpdateInDto m) =>
            _operationFactory.New<DashboardUpdate>().ExecuteAsync(m);

        [NeedPermission("Tenant.Dashboard.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<DashboardRemove>().ExecuteAsync(m);

        // ========== Customized Actions:

        [NeedPermission]
        [HttpGet("load")]
        public Task<List<DashboardDto>?> GetDashboards([FromRoute] GetDashboardsInDto m) =>
            _operationFactory.New<GetDashboards>().ExecuteAsync(m);

        [NeedPermission]
        [HttpPost("upsert")]
        public Task<int> DashboardUpsert([FromBody] DashboardUpsertInDto m) =>
            _operationFactory.New<DashboardUpsert>().ExecuteAsync(m);
    }
}
