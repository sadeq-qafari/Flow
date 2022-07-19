using System.Collections.Generic;
using System.Threading.Tasks;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;
using Core.Operations.ReportDbServer;
using Core.Operations.ReportDbServer.Commands;
using Core.Operations.ReportDbServer.Dtos;
using Core.Operations.ReportDbServer.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class ReportDbServerController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public ReportDbServerController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Core.ReportDbServer.Read")]
        [HttpGet]
        public Task<QueryPage<ReportDbServerDto>?> Get([FromQuery] DbQueryPageInDto m) => 
            _operationFactory.New<GetReportDbServerPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) => 
            _operationFactory.New<GetReportDbServerAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Core.ReportDbServer.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<ReportDbServer>?> GetByIds([FromQuery] DbQueryByIdsInDto m) => 
            _operationFactory.New<GetReportDbServerByIds>().ExecuteAsync(m);

        [NeedPermission("Core.ReportDbServer.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetReportDbServerExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ReportDbServer.xlsx");
        

        [NeedPermission("Core.ReportDbServer.Read")]
        [HttpGet("{id}")]
        public Task<ReportDbServer?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetReportDbServer>().ExecuteAsync(m);

        [NeedPermission("Core.ReportDbServer.Create")]
        [HttpPost]
        public Task<long> Add(ReportDbServerAddInDto m) =>
            _operationFactory.New<ReportDbServerAdd>().ExecuteAsync(m);

        [NeedPermission("Core.ReportDbServer.Update")]
        [HttpPut]
        public Task<bool> Update(ReportDbServerUpdateInDto m) =>
            _operationFactory.New<ReportDbServerUpdate>().ExecuteAsync(m);

        [NeedPermission("Core.ReportDbServer.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<ReportDbServerRemove>().ExecuteAsync(m);
    }
}