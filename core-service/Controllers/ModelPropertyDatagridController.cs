using System.Collections.Generic;
using System.Threading.Tasks;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;
using Core.Operations.ModelPropertyDatagrid;
using Core.Operations.ModelPropertyDatagrid.Commands;
using Core.Operations.ModelPropertyDatagrid.Dto;
using Core.Operations.ModelPropertyDatagrid.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class ModelPropertyDatagridController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public ModelPropertyDatagridController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Core.ModelPropertyDatagrid.Read")]
        [HttpGet]
        public Task<QueryPage<ModelPropertyDatagridDto>?> Get([FromQuery] DbQueryPageInDto m) =>
            _operationFactory.New<GetModelPropertyDatagridPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetModelPropertyDatagridAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Core.ModelPropertyDatagrid.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<ModelPropertyDatagrid>?> GetByIds([FromQuery] DbQueryByIdsInDto m) =>
            _operationFactory.New<GetModelPropertyDatagridByIds>().ExecuteAsync(m);

        [NeedPermission("Core.ModelPropertyDatagrid.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetModelPropertyDatagridExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ModelPropertyDatagrid.xlsx");


        [NeedPermission("Core.ModelPropertyDatagrid.Read")]
        [HttpGet("{id}")]
        public Task<ModelPropertyDatagrid?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetModelPropertyDatagrid>().ExecuteAsync(m);

        [NeedPermission("Core.ModelPropertyDatagrid.Create")]
        [HttpPost]
        public Task<long> Add(AddModelPropertyDatagridInDto m) =>
            _operationFactory.New<AddModelPropertyDatagrid>().ExecuteAsync(m);

        [NeedPermission("Core.ModelPropertyDatagrid.Update")]
        [HttpPut]
        public Task<bool> Update(UpdateModelPropertyDatagridInDto m) =>
            _operationFactory.New<UpdateModelPropertyDatagrid>().ExecuteAsync(m);

        [NeedPermission("Core.ModelPropertyDatagrid.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<RemoveModelPropertyDatagrid>().ExecuteAsync(m);
    }
}
