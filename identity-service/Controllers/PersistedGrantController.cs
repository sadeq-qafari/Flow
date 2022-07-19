using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Operations.Database.PersistedGrant;
using Identity.Operations.Database.PersistedGrant.Commands;
using Identity.Operations.Database.PersistedGrant.Dtos;
using Identity.Operations.Database.PersistedGrant.Queries;
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
    public class PersistedGrantController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public PersistedGrantController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Identity.PersistedGrant.Read")]
        [HttpGet]
        public Task<QueryPage<PersistedGrantDto>?> Get([FromQuery] DbQueryPageInDto m) =>
            _operationFactory.New<GetPersistedGrantPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetPersistedGrantAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Identity.PersistedGrant.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<PersistedGrant>?> GetByIds([FromQuery] DbQueryByIdsInDto m) =>
            _operationFactory.New<GetPersistedGrantByIds>().ExecuteAsync(m);

        [NeedPermission("Identity.PersistedGrant.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetPersistedGrantExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "PersistedGrant.xlsx");


        [NeedPermission("Identity.PersistedGrant.Read")]
        [HttpGet("{id}")]
        public Task<PersistedGrant?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetPersistedGrant>().ExecuteAsync(m);

        [NeedPermission("Identity.PersistedGrant.Create")]
        [HttpPost]
        public Task<long> Add(PersistedGrantAddInDto m) =>
            _operationFactory.New<PersistedGrantAdd>().ExecuteAsync(m);

        [NeedPermission("Identity.PersistedGrant.Update")]
        [HttpPut]
        public Task<bool> Update(PersistedGrantUpdateInDto m) =>
            _operationFactory.New<PersistedGrantUpdate>().ExecuteAsync(m);

        [NeedPermission("Identity.PersistedGrant.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<PersistedGrantRemove>().ExecuteAsync(m);
    }
}
