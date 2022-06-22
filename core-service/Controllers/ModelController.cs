using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Operations.Model;
using Core.Operations.Model.Commands;
using Core.Operations.Model.Dto;
using Core.Operations.Model.Queries;
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
    public class ModelController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public ModelController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Core.Model.Read")]
        [HttpGet]
        public Task<QueryPage<ModelDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetModelPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetModelAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Core.Model.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Model>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetModelByIds>().ExecuteAsync(m);

        [NeedPermission("Core.Model.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetModelExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Model.xlsx");


        [NeedPermission]
        [HttpGet("{id}")]
        public Task<ModelDto?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetModel>().ExecuteAsync(m);

        [NeedPermission("Core.Model.Create")]
        [HttpPost]
        public Task<long> Add(AddModelInDto m) =>
            _operationFactory.New<AddModel>().ExecuteAsync(m);

        [NeedPermission("Core.Model.Update")]
        [HttpPut]
        public Task<bool> Update(UpdateModelInDto m) =>
            _operationFactory.New<UpdateModel>().ExecuteAsync(m);

        [NeedPermission("Core.Model.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<RemoveModel>().ExecuteAsync(m);
    }
}
