using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Operations.Report;
using Core.Operations.Report.Commands;
using Core.Operations.Report.Dtos;
using Core.Operations.Report.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Saanaa.Core.AspNetCore.Security;
using Saanaa.Core.Meteor.Dto;

namespace Core.Controllers
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

        [NeedPermission("Core.Report.Read")]
        [HttpGet]
        public Task<QueryPage<ReportDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetReportPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetReportAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Core.Report.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Report>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetReportByIds>().ExecuteAsync(m);

        [NeedPermission("Core.Report.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetReportExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Report.xlsx");


        [NeedPermission("Core.Report.Read")]
        [HttpGet("{id}")]
        public Task<Report?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetReport>().ExecuteAsync(m);

        [NeedPermission("Core.Report.Create")]
        [HttpPost]
        public Task<long> Add(ReportAddInDto m) =>
            _operationFactory.New<ReportAdd>().ExecuteAsync(m);

        [NeedPermission("Core.Report.Update")]
        [HttpPut]
        public Task<bool> Update(ReportUpdateInDto m) =>
            _operationFactory.New<ReportUpdate>().ExecuteAsync(m);

        [NeedPermission("Core.Report.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<ReportRemove>().ExecuteAsync(m);

        // ========= custom actions

        [NeedPermission]
        [HttpPost("execute")]
        public Task<QueryPage<dynamic>?> Get([FromBody] SaanaaDbQueryReportInDto m)
        {
            return _operationFactory.New<ExecuteReport>().ExecuteAsync(m);
        }

        [HttpGet("info/{name}")]
        public Task<Report?> Info([FromRoute] string name) =>
            _operationFactory.New<GetReportInfo>().ExecuteAsync(name);

        [HttpPut("save")]
        public Task<bool> Save([FromBody] ReportSaveTemplateInDto m) =>
            _operationFactory.New<ReportSaveTemplate>().ExecuteAsync(m);

    }
}
