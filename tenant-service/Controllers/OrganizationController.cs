using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Core.AspNetCore.Security;
using Core.Meteor;
using Core.Meteor.Dto;
using Tenant.Operations.Organization;
using Tenant.Operations.Organization.Commands;
using Tenant.Operations.Organization.Dto;
using Tenant.Operations.Organization.Queries;

namespace Tenant.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class OrganizationController : ControllerBase
    {
        private readonly OperationFactory _operationFactory;

        public OrganizationController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Tenant.Organization.Read")]
        [HttpGet]
        public Task<QueryPage<OrganizationDto>?> Get([FromQuery] DbQueryPageInDto m) =>
            _operationFactory.New<GetOrganizationPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetOrganizationAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Tenant.Organization.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Organization>?> GetByIds([FromQuery] DbQueryByIdsInDto m) =>
            _operationFactory.New<GetOrganizationByIds>().ExecuteAsync(m);

        [NeedPermission("Tenant.Organization.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetOrganizationExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Organization.xlsx");


        [NeedPermission("Tenant.Organization.Read")]
        [HttpGet("{id}")]
        public Task<OrganizationDto?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetOrganization>().ExecuteAsync(m);

        [NeedPermission("Tenant.Organization.Create")]
        [HttpPost]
        public Task<long> Add(AddOrganizationInDto m) =>
            _operationFactory.New<AddOrganization>().ExecuteAsync(m);

        [NeedPermission("Tenant.Organization.Update")]
        [HttpPut]
        public Task<bool> Update(UpdateOrganizationInDto m) =>
            _operationFactory.New<UpdateOrganization>().ExecuteAsync(m);

        [NeedPermission("Tenant.Organization.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<RemoveOrganization>().ExecuteAsync(m);

        // ========= Customized Actions:

        [NeedPermission]
        [HttpGet("info")]
        public Task<OrganizationInfoDto?> GetInfo([FromQuery] GetOrganizationInfoInDto m) =>
            _operationFactory.New<GetOrganizationInfo>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("infoById")]
        public Task<OrganizationInfoDto?> GetInfo([FromQuery] int tenantId)
        {
            var m = new GetOrganizationInfoInDto()
            {
                TenantId = tenantId
            };
            return _operationFactory.New<GetOrganizationInfo>().ExecuteAsync(m);
        }


        [HttpGet("infoByUrl")]
        public Task<OrganizationInfoDto?> GetInfoByUrl([FromQuery] GetOrganizationInfoInDto m)
        {
            m.TenantId = SqTenants.GetTenant(HttpContext)!.Id;
            return _operationFactory.New<GetOrganizationInfo>().ExecuteAsync(m);
        }

        [NeedPermission]
        [HttpGet("incompleteInformation")]
        public async Task<IEnumerable<OrganizationIncompleteInformationDto?>?> GetOrganizationIncompleteInformation()
        {
            var tenantId = SqTenants.GetTenant(HttpContext)!.Id;
            return await _operationFactory.New<GetOrganizationIncompleteInformation>().ExecuteAsync(tenantId);
        }
    }
}
