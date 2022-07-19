using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Operations.Database.ApiScope;
using Identity.Operations.Database.ApiScope.Commands;
using Identity.Operations.Database.ApiScope.Dtos;
using Identity.Operations.Database.ApiScope.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;

namespace Identity.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class ApiScopeController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public ApiScopeController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Identity.ApiScope.Read")]
        [HttpGet]
        public Task<QueryPage<ApiScopeDto>?> Get([FromQuery] DbQueryPageInDto m) =>
            _operationFactory.New<GetApiScopePage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetApiScopeAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Identity.ApiScope.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<ApiScope>?> GetByIds([FromQuery] DbQueryByIdsInDto m) =>
            _operationFactory.New<GetApiScopeByIds>().ExecuteAsync(m);

        [NeedPermission("Identity.ApiScope.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetApiScopeExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ApiScope.xlsx");


        [NeedPermission("Identity.ApiScope.Read")]
        [HttpGet("{id}")]
        public Task<ApiScope?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetApiScope>().ExecuteAsync(m);

        [NeedPermission("Identity.ApiScope.Create")]
        [HttpPost]
        public Task<long> Add(ApiScopeAddInDto m) =>
            _operationFactory.New<ApiScopeAdd>().ExecuteAsync(m);

        [NeedPermission("Identity.ApiScope.Update")]
        [HttpPut]
        public Task<bool> Update(ApiScopeUpdateInDto m) =>
            _operationFactory.New<ApiScopeUpdate>().ExecuteAsync(m);

        [NeedPermission("Identity.ApiScope.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<ApiScopeRemove>().ExecuteAsync(m);
    }
}
