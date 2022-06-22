using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Operations.Database.ApiResource;
using Identity.Operations.Database.ApiResource.Commands;
using Identity.Operations.Database.ApiResource.Dtos;
using Identity.Operations.Database.ApiResource.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Saanaa.Core.AspNetCore.Security;
using Saanaa.Core.Meteor.Dto;

namespace Identity.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class ApiResourceController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public ApiResourceController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Identity.ApiResource.Read")]
        [HttpGet]
        public Task<QueryPage<ApiResourceDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetApiResourcePage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetApiResourceAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Identity.ApiResource.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<ApiResource>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetApiResourceByIds>().ExecuteAsync(m);

        [NeedPermission("Identity.ApiResource.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetApiResourceExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ApiResource.xlsx");


        [NeedPermission("Identity.ApiResource.Read")]
        [HttpGet("{id}")]
        public Task<ApiResource?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetApiResource>().ExecuteAsync(m);

        [NeedPermission("Identity.ApiResource.Create")]
        [HttpPost]
        public Task<long> Add(ApiResourceAddInDto m) =>
            _operationFactory.New<ApiResourceAdd>().ExecuteAsync(m);

        [NeedPermission("Identity.ApiResource.Update")]
        [HttpPut]
        public Task<bool> Update(ApiResourceUpdateInDto m) =>
            _operationFactory.New<ApiResourceUpdate>().ExecuteAsync(m);

        [NeedPermission("Identity.ApiResource.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<ApiResourceRemove>().ExecuteAsync(m);
    }
}
