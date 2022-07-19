using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Operations.Database.TenantUrl;
using Identity.Operations.Database.TenantUrl.Commands;
using Identity.Operations.Database.TenantUrl.Dtos;
using Identity.Operations.Database.TenantUrl.Queries;
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
    public class TenantUrlController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public TenantUrlController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Identity.TenantUrl.Read")]
        [HttpGet]
        public Task<QueryPage<TenantUrlDto>?> Get([FromQuery] DbQueryPageInDto m) =>
            _operationFactory.New<GetTenantUrlPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetTenantUrlAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Identity.TenantUrl.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<TenantUrl>?> GetByIds([FromQuery] DbQueryByIdsInDto m) =>
            _operationFactory.New<GetTenantUrlByIds>().ExecuteAsync(m);

        [NeedPermission("Identity.TenantUrl.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetTenantUrlExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "TenantUrl.xlsx");


        [NeedPermission("Identity.TenantUrl.Read")]
        [HttpGet("{id}")]
        public Task<TenantUrl?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetTenantUrl>().ExecuteAsync(m);

        [NeedPermission("Identity.TenantUrl.Create")]
        [HttpPost]
        public Task<long> Add(TenantUrlAddInDto m) =>
            _operationFactory.New<TenantUrlAdd>().ExecuteAsync(m);

        [NeedPermission("Identity.TenantUrl.Update")]
        [HttpPut]
        public Task<bool> Update(TenantUrlUpdateInDto m) =>
            _operationFactory.New<TenantUrlUpdate>().ExecuteAsync(m);

        [NeedPermission("Identity.TenantUrl.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<TenantUrlRemove>().ExecuteAsync(m);
    }
}
