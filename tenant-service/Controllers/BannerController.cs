using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Core.AspNetCore.Security;
using Core.Meteor;
using Core.Meteor.Dto;
using Tenant.Operations.Banner;
using Tenant.Operations.Banner.Commands;
using Tenant.Operations.Banner.Dtos;
using Tenant.Operations.Banner.Queries;

namespace Tenant.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class BannerController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public BannerController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Tenant.Banner.Read")]
        [HttpGet]
        public Task<QueryPage<BannerDto>?> Get([FromQuery] DbQueryPageInDto m) =>
            _operationFactory.New<GetBannerPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetBannerAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Tenant.Banner.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Banner>?> GetByIds([FromQuery] DbQueryByIdsInDto m) =>
            _operationFactory.New<GetBannerByIds>().ExecuteAsync(m);

        [NeedPermission("Tenant.Banner.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetBannerExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Banner.xlsx");


        [NeedPermission("Tenant.Banner.Read")]
        [HttpGet("{id}")]
        public Task<Banner?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetBanner>().ExecuteAsync(m);

        [NeedPermission("Tenant.Banner.Create")]
        [HttpPost]
        public Task<long> Add(BannerAddInDto m) =>
            _operationFactory.New<BannerAdd>().ExecuteAsync(m);

        [NeedPermission("Tenant.Banner.Update")]
        [HttpPut]
        public Task<bool> Update(BannerUpdateInDto m) =>
            _operationFactory.New<BannerUpdate>().ExecuteAsync(m);

        [NeedPermission("Tenant.Banner.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<BannerRemove>().ExecuteAsync(m);

        // ============= Custom Actions:

        [HttpGet("list")]
        public Task<IEnumerable<Banner>?> GetBannerList()
        {
            var tenantId = SqTenants.GetTenant(HttpContext)!.Id;
            return _operationFactory.New<GetBannerList>().ExecuteAsync(tenantId);
        }
    }
}
