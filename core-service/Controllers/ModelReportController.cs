using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Operations.ModelReport;
using Core.Operations.ModelReport.Commands;
using Core.Operations.ModelReport.Dtos;
using Core.Operations.ModelReport.Queries;
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
    public class ModelReportController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public ModelReportController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Core.ModelReport.Read")]
        [HttpGet]
        public Task<QueryPage<ModelReportDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetModelReportPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetModelReportAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Core.ModelReport.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<ModelReport>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetModelReportByIds>().ExecuteAsync(m);

        [NeedPermission("Core.ModelReport.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetModelReportExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ModelReport.xlsx");


        [NeedPermission("Core.ModelReport.Read")]
        [HttpGet("{id}")]
        public Task<ModelReport?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetModelReport>().ExecuteAsync(m);

        [NeedPermission("Core.ModelReport.Create")]
        [HttpPost]
        public Task<long> Add(ModelReportAddInDto m) =>
            _operationFactory.New<ModelReportAdd>().ExecuteAsync(m);

        [NeedPermission("Core.ModelReport.Update")]
        [HttpPut]
        public Task<bool> Update(ModelReportUpdateInDto m) =>
            _operationFactory.New<ModelReportUpdate>().ExecuteAsync(m);

        [NeedPermission]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<ModelReportRemove>().ExecuteAsync(m);

        // ============ Custom Actions:

        [NeedPermission]
        [HttpGet("reports")]
        public Task<IEnumerable<ModelReportInfoDto>?> GetModelReports([FromQuery] ModelReportsInDto m) =>
            _operationFactory.New<GetModelReports>().ExecuteAsync(m);

        [NeedPermission]
        [HttpPost("upsert")]
        public Task<int> ModelReportUpsert([FromBody] ModelReportUpdateInDto m) =>
            _operationFactory.New<ModelReportUpsert>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("info/{id}")]
        public Task<ModelReportInfoDto?> GetReportInfo([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetModelReportInfo>().ExecuteAsync(m);


    }
}
