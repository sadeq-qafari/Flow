using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Operations.Database.IdentityResource;
using Identity.Operations.Database.IdentityResource.Commands;
using Identity.Operations.Database.IdentityResource.Dtos;
using Identity.Operations.Database.IdentityResource.Queries;
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
    public class IdentityResourceController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public IdentityResourceController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Identity.IdentityResource.Read")]
        [HttpGet]
        public Task<QueryPage<IdentityResourceDto>?> Get([FromQuery] DbQueryPageInDto m) =>
            _operationFactory.New<GetIdentityResourcePage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetIdentityResourceAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Identity.IdentityResource.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<IdentityResource>?> GetByIds([FromQuery] DbQueryByIdsInDto m) =>
            _operationFactory.New<GetIdentityResourceByIds>().ExecuteAsync(m);

        [NeedPermission("Identity.IdentityResource.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetIdentityResourceExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "IdentityResource.xlsx");


        [NeedPermission("Identity.IdentityResource.Read")]
        [HttpGet("{id}")]
        public Task<IdentityResource?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetIdentityResource>().ExecuteAsync(m);

        [NeedPermission("Identity.IdentityResource.Create")]
        [HttpPost]
        public Task<long> Add(IdentityResourceAddInDto m) =>
            _operationFactory.New<IdentityResourceAdd>().ExecuteAsync(m);

        [NeedPermission("Identity.IdentityResource.Update")]
        [HttpPut]
        public Task<bool> Update(IdentityResourceUpdateInDto m) =>
            _operationFactory.New<IdentityResourceUpdate>().ExecuteAsync(m);

        [NeedPermission("Identity.IdentityResource.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<IdentityResourceRemove>().ExecuteAsync(m);
    }
}
