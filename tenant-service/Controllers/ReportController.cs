using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Saanaa.Core.AspNetCore.Security;
using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;
using Tenant.Operations.Dashboard.Dtos;
using Tenant.Operations.Report;
using Tenant.Operations.Report.Commands;
using Tenant.Operations.Report.Dtos;
using Tenant.Operations.Report.Queries;

namespace Tenant.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public ReportController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Tenant.Report.Read")]
        [HttpGet]
        public Task<QueryPage<ReportDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetReportPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetReportAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Tenant.Report.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Report>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetReportByIds>().ExecuteAsync(m);

        [NeedPermission("Tenant.Report.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetReportExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Report.xlsx");


        [NeedPermission("Tenant.Report.Read")]
        [HttpGet("{id}")]
        public Task<Report?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetReport>().ExecuteAsync(m);

        [NeedPermission("Tenant.Report.Create")]
        [HttpPost]
        public Task<long> Add(ReportAddInDto m) =>
            _operationFactory.New<ReportAdd>().ExecuteAsync(m);

        [NeedPermission("Tenant.Report.Update")]
        [HttpPut]
        public Task<bool> Update(ReportUpdateInDto m) =>
            _operationFactory.New<ReportUpdate>().ExecuteAsync(m);

        [NeedPermission("Tenant.Report.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<ReportRemove>().ExecuteAsync(m);

        // ======= Customized Actions:

        [NeedPermission]
        [HttpGet("all")]
        public Task<IEnumerable<Report>?> GetReportsByTenantService([FromRoute] GetDashboardsInDto m) =>
            _operationFactory.New<GetReportsByTenantService>().ExecuteAsync(m);

        [HttpGet("name")]
        public Task<List<object>?> GetReportByName([FromQuery] ReportByNameInDto m)
        {
            m.TenantId = SaanaaTenants.GetTenant(HttpContext).Id;
            return _operationFactory.New<GetReportByName>().ExecuteAsync(m);
        }
    }
}
