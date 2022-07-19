using System.Collections.Generic;
using System.Threading.Tasks;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;
using Core.Operations.ModelFilter;
using Core.Operations.ModelFilter.Commands;
using Core.Operations.ModelFilter.Dtos;
using Core.Operations.ModelFilter.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class ModelFilterController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public ModelFilterController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Core.ModelFilter.Read")]
        [HttpGet]
        public Task<QueryPage<ModelFilterDto>?> Get([FromQuery] DbQueryPageInDto m) => 
            _operationFactory.New<GetModelFilterPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) => 
            _operationFactory.New<GetModelFilterAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Core.ModelFilter.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<ModelFilter>?> GetByIds([FromQuery] DbQueryByIdsInDto m) => 
            _operationFactory.New<GetModelFilterByIds>().ExecuteAsync(m);

        [NeedPermission("Core.ModelFilter.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetModelFilterExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ModelFilter.xlsx");
        

        [NeedPermission("Core.ModelFilter.Read")]
        [HttpGet("{id}")]
        public Task<ModelFilter?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetModelFilter>().ExecuteAsync(m);

        [NeedPermission("Core.ModelFilter.Create")]
        [HttpPost]
        public Task<long> Add(ModelFilterAddInDto m) =>
            _operationFactory.New<ModelFilterAdd>().ExecuteAsync(m);

        [NeedPermission("Core.ModelFilter.Update")]
        [HttpPut]
        public Task<bool> Update(ModelFilterUpdateInDto m) =>
            _operationFactory.New<ModelFilterUpdate>().ExecuteAsync(m);

        [NeedPermission("Core.ModelFilter.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<ModelFilterRemove>().ExecuteAsync(m);
    }
}
