using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Saanaa.Core.AspNetCore.Security;
using Saanaa.Core.Meteor.Dto;
using Tenant.Operations.EntityTag;
using Tenant.Operations.EntityTag.Commands;
using Tenant.Operations.EntityTag.Dtos;
using Tenant.Operations.EntityTag.Queries;

namespace Tenant.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class EntityTagController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public EntityTagController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Tenant.EntityTag.Read")]
        [HttpGet]
        public Task<QueryPage<EntityTagDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetEntityTagPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetEntityTagAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Tenant.EntityTag.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<EntityTag>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetEntityTagByIds>().ExecuteAsync(m);

        [NeedPermission("Tenant.EntityTag.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetEntityTagExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "EntityTag.xlsx");


        [NeedPermission("Tenant.EntityTag.Read")]
        [HttpGet("{id}")]
        public Task<EntityTag?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetEntityTag>().ExecuteAsync(m);

        [NeedPermission("Tenant.EntityTag.Create")]
        [HttpPost]
        public Task<long> Add(EntityTagAddInDto m) =>
            _operationFactory.New<EntityTagAdd>().ExecuteAsync(m);

        [NeedPermission("Tenant.EntityTag.Update")]
        [HttpPut]
        public Task<bool> Update(EntityTagUpdateInDto m) =>
            _operationFactory.New<EntityTagUpdate>().ExecuteAsync(m);

        [NeedPermission("Tenant.EntityTag.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<EntityTagRemove>().ExecuteAsync(m);

        // Customized Actions:
        [NeedPermission(Policies = "backend")]
        [HttpPost("merge")]
        public Task<bool> Merge(EntityTagMergeInDto m) =>
            _operationFactory.New<EntityTagMerge>().ExecuteAsync(m);
    }
}
