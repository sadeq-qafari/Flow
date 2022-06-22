using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Operations.ModelProperty;
using Core.Operations.ModelProperty.Commands;
using Core.Operations.ModelProperty.Dto;
using Core.Operations.ModelProperty.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Saanaa.Core.AspNetCore.Security;
using Saanaa.Core.Meteor.Dto;

namespace Core.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class ModelPropertyController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public ModelPropertyController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Core.ModelProperty.Read")]
        [HttpGet]
        public Task<QueryPage<ModelPropertyDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetModelPropertyPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetModelPropertyAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Core.ModelProperty.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<ModelProperty>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetModelPropertyByIds>().ExecuteAsync(m);

        [NeedPermission("Core.ModelProperty.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetModelPropertyExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ModelProperty.xlsx");


        [NeedPermission("Core.ModelProperty.Read")]
        [HttpGet("{id}")]
        public Task<ModelProperty?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetModelProperty>().ExecuteAsync(m);

        [NeedPermission("Core.ModelProperty.Create")]
        [HttpPost]
        public Task<long> Add(AddModelPropertyInDto m) =>
            _operationFactory.New<AddModelProperty>().ExecuteAsync(m);

        [NeedPermission("Core.ModelProperty.Update")]
        [HttpPut]
        public Task<bool> Update(UpdateModelPropertyInDto m) =>
            _operationFactory.New<UpdateModelProperty>().ExecuteAsync(m);

        [NeedPermission("Core.ModelProperty.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<RemoveModelProperty>().ExecuteAsync(m);
    }
}
