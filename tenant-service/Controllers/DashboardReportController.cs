using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;
using Tenant.Operations.DashboardReport;
using Tenant.Operations.DashboardReport.Commands;
using Tenant.Operations.DashboardReport.Dtos;
using Tenant.Operations.DashboardReport.Queries;

namespace Tenant.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class DashboardReportController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public DashboardReportController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Tenant.DashboardReport.Read")]
        [HttpGet]
        public Task<QueryPage<DashboardReportDto>?> Get([FromQuery] DbQueryPageInDto m) => 
            _operationFactory.New<GetDashboardReportPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) => 
            _operationFactory.New<GetDashboardReportAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Tenant.DashboardReport.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<DashboardReport>?> GetByIds([FromQuery] DbQueryByIdsInDto m) => 
            _operationFactory.New<GetDashboardReportByIds>().ExecuteAsync(m);

        [NeedPermission("Tenant.DashboardReport.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetDashboardReportExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DashboardReport.xlsx");
        

        [NeedPermission("Tenant.DashboardReport.Read")]
        [HttpGet("{id}")]
        public Task<DashboardReport?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetDashboardReport>().ExecuteAsync(m);

        [NeedPermission("Tenant.DashboardReport.Create")]
        [HttpPost]
        public Task<long> Add(DashboardReportAddInDto m) =>
            _operationFactory.New<DashboardReportAdd>().ExecuteAsync(m);

        [NeedPermission("Tenant.DashboardReport.Update")]
        [HttpPut]
        public Task<bool> Update(DashboardReportUpdateInDto m) =>
            _operationFactory.New<DashboardReportUpdate>().ExecuteAsync(m);

        [NeedPermission("Tenant.DashboardReport.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<DashboardReportRemove>().ExecuteAsync(m);
    }
}