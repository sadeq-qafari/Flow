using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Operations.Version;
using Core.Operations.Version.Commands;
using Core.Operations.Version.Dto;
using Core.Operations.Version.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Saanaa.Core.AspNetCore.Security;
using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Core.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class VersionController : ControllerBase
    {
        private readonly OperationFactory _operationFactory;

        public VersionController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Core.Version.Read")]
        [HttpGet]
        public Task<QueryPage<VersionDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetVersionPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetVersionAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Core.Version.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Version>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetVersionByIds>().ExecuteAsync(m);

        [NeedPermission("Core.Version.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetVersionExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Version.xlsx");


        [NeedPermission("Core.Version.Read")]
        [HttpGet("{id}")]
        public Task<Version?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetVersion>().ExecuteAsync(m);

        [NeedPermission("Core.Version.Create")]
        [HttpPost]
        public Task<long> Add(AddVersionInDto m) =>
            _operationFactory.New<AddVersion>().ExecuteAsync(m);

        [NeedPermission("Core.Version.Update")]
        [HttpPut]
        public Task<bool> Update(UpdateVersionInDto m) =>
            _operationFactory.New<UpdateVersion>().ExecuteAsync(m);

        [NeedPermission("Core.Version.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<RemoveVersion>().ExecuteAsync(m);

        // ============== Custom Actions:

        [HttpGet("changeLog/{AppType}")]
        public async Task<IEnumerable<Version>?> GetChangeLog([FromRoute] GetChangeLogInDto m)
        {
            m.TenantId = SaanaaTenants.GetTenant(HttpContext)!.Id;
            return await _operationFactory.New<GetChangeLog>().ExecuteAsync(m);
        }

        [HttpGet("check")]
        public async Task<bool> CheckVersion([FromQuery] CheckVersionInDto m)
        {
            m.TenantId = SaanaaTenants.GetTenant(HttpContext)!.Id;
            return await _operationFactory.New<CheckVersion>().ExecuteAsync(m);
        }


    }
}
