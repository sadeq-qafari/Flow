using System.Collections.Generic;
using System.Threading.Tasks;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;
using Flow.Operations.Lookup;
using Flow.Operations.Lookup.Commands;
using Flow.Operations.Lookup.Dtos;
using Flow.Operations.Lookup.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class LookupController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public LookupController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Flow.Lookup.Read")]
        [HttpGet]
        public Task<QueryPage<LookupDto>?> Get([FromQuery] DbQueryPageInDto m) =>
            _operationFactory.New<GetLookupPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetLookupAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Flow.Lookup.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Lookup>?> GetByIds([FromQuery] DbQueryByIdsInDto m) =>
            _operationFactory.New<GetLookupByIds>().ExecuteAsync(m);

        [NeedPermission("Flow.Lookup.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetLookupExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Lookup.xlsx");

        [NeedPermission("Flow.Lookup.Create")]
        [HttpPost]
        public Task<long> Add(LookupAddInDto m) =>
            _operationFactory.New<LookupAdd>().ExecuteAsync(m);

        [NeedPermission("Flow.Lookup.Update")]
        [HttpPut]
        public Task<bool> Update(LookupUpdateInDto m) =>
            _operationFactory.New<LookupUpdate>().ExecuteAsync(m);

        [NeedPermission("Flow.Lookup.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<LookupRemove>().ExecuteAsync(m);

        // ========= Custom Actions:

        [NeedPermission("Flow.Lookup.Create")]
        [HttpPost("upsert")]
        public Task<int> Upsert(LookupUpsertInDto m) =>
            _operationFactory.New<LookupUpsert>().ExecuteAsync(m);

        [NeedPermission("Flow.Lookup.Read")]
        [HttpGet("{id}")]
        public Task<LookupInfoDto?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetLookupInfo>().ExecuteAsync(m);
    }
}
