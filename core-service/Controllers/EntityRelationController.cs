using System.Collections.Generic;
using System.Threading.Tasks;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;
using Core.Operations.EntityRelation;
using Core.Operations.EntityRelation.Commands;
using Core.Operations.EntityRelation.Dto;
using Core.Operations.EntityRelation.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using EntityRelationDto = Core.Operations.EntityRelation.Dto.EntityRelationDto;

namespace Core.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class EntityRelationController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public EntityRelationController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Core.EntityRelation.Read")]
        [HttpGet]
        public Task<QueryPage<EntityRelationDto>?> Get([FromQuery] DbQueryPageInDto m) =>
            _operationFactory.New<GetEntityRelationPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetEntityRelationAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Core.EntityRelation.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<EntityRelation>?> GetByIds([FromQuery] DbQueryByIdsInDto m) =>
            _operationFactory.New<GetEntityRelationByIds>().ExecuteAsync(m);


        [NeedPermission("Core.EntityRelation.Read")]
        [HttpGet("{id}")]
        public Task<EntityRelation?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetEntityRelation>().ExecuteAsync(m);

        [NeedPermission("Core.EntityRelation.Create")]
        [HttpPost]
        public Task<long> Add(AddEntityRelationInDto m) =>
            _operationFactory.New<AddEntityRelation>().ExecuteAsync(m);

        [NeedPermission("Core.EntityRelation.Update")]
        [HttpPut]
        public Task<bool> Update(UpdateEntityRelationInDto m) =>
            _operationFactory.New<UpdateEntityRelation>().ExecuteAsync(m);

        [NeedPermission("Core.EntityRelation.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<RemoveEntityRelation>().ExecuteAsync(m);
    }
}
