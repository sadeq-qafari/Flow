using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;
using Tenant.Operations.OrganizationDetail;
using Tenant.Operations.OrganizationDetail.Commands;
using Tenant.Operations.OrganizationDetail.Dtos;
using Tenant.Operations.OrganizationDetail.Queries;

namespace Tenant.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class OrganizationDetailController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public OrganizationDetailController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Tenant.OrganizationDetail.Read")]
        [HttpGet]
        public Task<QueryPage<OrganizationDetailDto>?> Get([FromQuery] DbQueryPageInDto m) =>
            _operationFactory.New<GetOrganizationDetailPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetOrganizationDetailAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Tenant.OrganizationDetail.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<OrganizationDetail>?> GetByIds([FromQuery] DbQueryByIdsInDto m) =>
            _operationFactory.New<GetOrganizationDetailByIds>().ExecuteAsync(m);

        [NeedPermission("Tenant.OrganizationDetail.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetOrganizationDetailExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "OrganizationDetail.xlsx");


        [NeedPermission("Tenant.OrganizationDetail.Read")]
        [HttpGet("{id}")]
        public Task<object?> GetOne([FromRoute] int id) =>
            _operationFactory.New<GetOrganizationDetail>().ExecuteAsync(id);

        [NeedPermission("Tenant.OrganizationDetail.Update")]
        [HttpPut]
        public Task<bool> Update(OrganizationDetailUpdateInDto m) =>
            _operationFactory.New<OrganizationDetailUpdate>().ExecuteAsync(m);

        [NeedPermission("Tenant.OrganizationDetail.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<OrganizationDetailRemove>().ExecuteAsync(m);

        // ============= Custom Actions:

        [NeedPermission("Tenant.OrganizationDetail.Update")]
        [HttpPost("upsert")]
        public Task<bool> Upsert(OrganizationDetailUpsertInDto m) =>
            _operationFactory.New<OrganizationDetailUpsert>().ExecuteAsync(m);

    }
}
