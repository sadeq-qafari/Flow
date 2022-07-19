using System.Collections.Generic;
using System.Threading.Tasks;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;
using Core.Operations.ModelPropertyElement;
using Core.Operations.ModelPropertyElement.Commands;
using Core.Operations.ModelPropertyElement.Dto;
using Core.Operations.ModelPropertyElement.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class ModelPropertyElementController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public ModelPropertyElementController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Core.ModelPropertyElement.Read")]
        [HttpGet]
        public Task<QueryPage<ModelPropertyElementDto>?> Get([FromQuery] DbQueryPageInDto m) =>
            _operationFactory.New<GetModelPropertyElementPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetModelPropertyElementAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Core.ModelPropertyElement.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<ModelPropertyElement>?> GetByIds([FromQuery] DbQueryByIdsInDto m) =>
            _operationFactory.New<GetModelPropertyElementByIds>().ExecuteAsync(m);

        [NeedPermission("Core.ModelPropertyElement.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetModelPropertyElementExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ModelPropertyElement.xlsx");


        [NeedPermission("Core.ModelPropertyElement.Read")]
        [HttpGet("{id}")]
        public Task<ModelPropertyElement?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetModelPropertyElement>().ExecuteAsync(m);

        [NeedPermission("Core.ModelPropertyElement.Create")]
        [HttpPost]
        public Task<long> Add(AddModelPropertyElementInDto m) =>
            _operationFactory.New<AddModelPropertyElement>().ExecuteAsync(m);

        [NeedPermission("Core.ModelPropertyElement.Update")]
        [HttpPut]
        public Task<bool> Update(UpdateModelPropertyElementInDto m) =>
            _operationFactory.New<UpdateModelPropertyElement>().ExecuteAsync(m);

        [NeedPermission("Core.ModelPropertyElement.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<RemoveModelPropertyElement>().ExecuteAsync(m);
    }
}
