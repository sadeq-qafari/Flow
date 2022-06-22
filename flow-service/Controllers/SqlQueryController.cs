using System.Collections.Generic;
using System.Threading.Tasks;
using Flow.Operations.SqlQuery;
using Flow.Operations.SqlQuery.Commands;
using Flow.Operations.SqlQuery.Dtos;
using Flow.Operations.SqlQuery.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Saanaa.Core.AspNetCore.Security;
using Saanaa.Core.Meteor.Dto;

namespace Flow.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class SqlQueryController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public SqlQueryController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Flow.SqlQuery.Read")]
        [HttpGet]
        public Task<QueryPage<SqlQueryDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) => 
            _operationFactory.New<GetSqlQueryPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) => 
            _operationFactory.New<GetSqlQueryAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Flow.SqlQuery.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<SqlQuery>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) => 
            _operationFactory.New<GetSqlQueryByIds>().ExecuteAsync(m);

        [NeedPermission("Flow.SqlQuery.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetSqlQueryExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SqlQuery.xlsx");
        

        [NeedPermission("Flow.SqlQuery.Read")]
        [HttpGet("{id}")]
        public Task<SqlQuery?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetSqlQuery>().ExecuteAsync(m);

        [NeedPermission("Flow.SqlQuery.Create")]
        [HttpPost]
        public Task<long> Add(SqlQueryAddInDto m) =>
            _operationFactory.New<SqlQueryAdd>().ExecuteAsync(m);

        [NeedPermission("Flow.SqlQuery.Update")]
        [HttpPut]
        public Task<bool> Update(SqlQueryUpdateInDto m) =>
            _operationFactory.New<SqlQueryUpdate>().ExecuteAsync(m);

        [NeedPermission("Flow.SqlQuery.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<SqlQueryRemove>().ExecuteAsync(m);
    }
}