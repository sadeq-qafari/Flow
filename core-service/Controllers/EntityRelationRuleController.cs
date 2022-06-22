using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Operations.EntityRelationRule;
using Core.Operations.EntityRelationRule.Commands;
using Core.Operations.EntityRelationRule.Dto;
using Core.Operations.EntityRelationRule.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Saanaa.Core.AspNetCore.Security;
using Saanaa.Core.Meteor.Dto;
using EntityRelationRuleDto = Core.Operations.EntityRelationRule.Dto.EntityRelationRuleDto;

namespace Core.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class EntityRelationRuleController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public EntityRelationRuleController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Core.EntityRelationRule.Read")]
        [HttpGet]
        public Task<QueryPage<EntityRelationRuleDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetEntityRelationRulePage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetEntityRelationRuleAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Core.EntityRelationRule.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<EntityRelationRule>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetEntityRelationRuleByIds>().ExecuteAsync(m);

        [NeedPermission("Core.EntityRelationRule.Read")]
        [HttpGet("{id}")]
        public Task<EntityRelationRule?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetEntityRelationRule>().ExecuteAsync(m);

        [NeedPermission("Core.EntityRelationRule.Create")]
        [HttpPost]
        public Task<long> Add(AddEntityRelationRuleInDto m) =>
            _operationFactory.New<AddEntityRelationRule>().ExecuteAsync(m);

        [NeedPermission("Core.EntityRelationRule.Update")]
        [HttpPut]
        public Task<bool> Update(UpdateEntityRelationRuleInDto m) =>
            _operationFactory.New<UpdateEntityRelationRule>().ExecuteAsync(m);

        [NeedPermission("Core.EntityRelationRule.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<RemoveEntityRelationRule>().ExecuteAsync(m);
    }
}
