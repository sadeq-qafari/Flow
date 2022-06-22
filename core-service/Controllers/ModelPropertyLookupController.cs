using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Operations.ModelPropertyLookup;
using Core.Operations.ModelPropertyLookup.Commands;
using Core.Operations.ModelPropertyLookup.Dto;
using Core.Operations.ModelPropertyLookup.Queries;
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
    public class ModelPropertyLookupController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public ModelPropertyLookupController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Core.ModelPropertyLookup.Read")]
        [HttpGet]
        public Task<QueryPage<ModelPropertyLookupDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetModelPropertyLookupPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetModelPropertyLookupAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Core.ModelPropertyLookup.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<ModelPropertyLookup>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetModelPropertyLookupByIds>().ExecuteAsync(m);

        [NeedPermission("Core.ModelPropertyLookup.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetModelPropertyLookupExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ModelPropertyLookup.xlsx");


        [NeedPermission("Core.ModelPropertyLookup.Read")]
        [HttpGet("{id}")]
        public Task<ModelPropertyLookup?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetModelPropertyLookup>().ExecuteAsync(m);

        [NeedPermission("Core.ModelPropertyLookup.Create")]
        [HttpPost]
        public Task<long> Add(AddModelPropertyLookupInDto m) =>
            _operationFactory.New<AddModelPropertyLookup>().ExecuteAsync(m);

        [NeedPermission("Core.ModelPropertyLookup.Update")]
        [HttpPut]
        public Task<bool> Update(UpdateModelPropertyLookupInDto m) =>
            _operationFactory.New<UpdateModelPropertyLookup>().ExecuteAsync(m);

        [NeedPermission("Core.ModelPropertyLookup.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<RemoveModelPropertyLookup>().ExecuteAsync(m);

        //============== Custom Actions:

        [HttpGet("items")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] GetModelPropertyLookupListInDto m) =>
            _operationFactory.New<GetModelPropertyLookupList>().ExecuteAsync(m);
    }
}
