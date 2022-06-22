using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Saanaa.Core.AspNetCore.Security;
using Saanaa.Core.Meteor.Dto;
using Tenant.Operations.Tag;
using Tenant.Operations.Tag.Commands;
using Tenant.Operations.Tag.Dto;
using Tenant.Operations.Tag.Queries;

namespace Tenant.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class TagController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public TagController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Tenant.Tag.Read")]
        [HttpGet]
        public Task<QueryPage<TagDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetTagPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetTagAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Tenant.Tag.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Tag>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetTagByIds>().ExecuteAsync(m);

        [NeedPermission("Tenant.Tag.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetTagExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Tag.xlsx");


        [NeedPermission("Tenant.Tag.Read")]
        [HttpGet("{id}")]
        public Task<Tag?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetTag>().ExecuteAsync(m);

        [NeedPermission("Tenant.Tag.Create")]
        [HttpPost]
        public Task<long> Add(AddTagInDto m) =>
            _operationFactory.New<AddTag>().ExecuteAsync(m);

        [NeedPermission("Tenant.Tag.Update")]
        [HttpPut]
        public Task<bool> Update(UpdateTagInDto m) =>
            _operationFactory.New<UpdateTag>().ExecuteAsync(m);

        [NeedPermission("Tenant.Tag.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<RemoveTag>().ExecuteAsync(m);

    }
}
