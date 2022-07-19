using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.AspNetCore;
using Core.AspNetCore.Security;
using Core.Dto;
using Core.Meteor;
using Core.Meteor.Dto;
using Core.Operations.Service.Commands;
using Core.Operations.Service.Dto;
using Core.Operations.Service.Queries;
using Meteor.AspCore.Filters;
using Meteor.Database;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly OperationFactory _operationFactory;
        private readonly LazyDbConnection _lazyDbConnection;

        public ServiceController(OperationFactory operationFactory, LazyDbConnection lazyDbConnection)
        {
            _operationFactory = operationFactory;
            _lazyDbConnection = lazyDbConnection;
        }

        [HttpGet("reload")]
        public async Task<ServicesDto> ReloadServices(string? names)
        {
            await SqServices.Reload(_lazyDbConnection, ServiceConfig.Get("api_gateway_url"));
            return GetServicesDto(names);
        }

        [HttpGet("config")]
        public async Task<ServicesDto?> GetServices(string names, long? version)
        {
            var requestedVersion = version.GetValueOrDefault(0);
            if (requestedVersion <= 0 || requestedVersion != SqServices.LatestVersion)
                return SqServices.Services.Count == 0
                    ? await ReloadServices(names)
                    : GetServicesDto(names);

            return null;
        }

        [HttpGet("generate")]
        public async Task<bool> GenerateServices(string name)
        {
            var builder = new ProjectBuilder(name, "D:/GeneratedProjects");
            await builder.Build();
            return true;
        }

        [NeedPermission("Core.Service.Read")]
        [HttpGet]
        public Task<QueryPage<ServiceDto>?> Get([FromQuery] DbQueryPageInDto m) =>
            _operationFactory.New<GetServicePage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetServiceAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Core.Service.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Operations.Service.Service>?> GetByIds([FromQuery] DbQueryByIdsInDto m) =>
            _operationFactory.New<GetServiceByIds>().ExecuteAsync(m);

        [NeedPermission("Core.Service.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetServiceExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Service.xlsx");


        [NeedPermission("Core.Service.Read")]
        [HttpGet("{id}")]
        public Task<Operations.Service.Service?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetService>().ExecuteAsync(m);

        [NeedPermission("Core.Service.Create")]
        [HttpPost]
        public Task<long> Add(AddServiceInDto m) =>
            _operationFactory.New<AddService>().ExecuteAsync(m);

        [NeedPermission("Core.Service.Update")]
        [HttpPut]
        public Task<bool> Update(UpdateServiceInDto m) =>
            _operationFactory.New<UpdateService>().ExecuteAsync(m);

        [NeedPermission("Core.Service.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<RemoveService>().ExecuteAsync(m);

        // ============ Custom Actions:

        private static ServicesDto GetServicesDto(string? names)
        {
            var serviceNames = names?.Split(',').Select(x => x.Trim()).ToList() ?? new List<string>();
            return new ServicesDto
            {
                Services = SqServices.GetServices(serviceNames),
                Version = SqServices.LatestVersion
            };
        }

        [NeedPermission]
        [HttpGet("services")]
        public async Task<ServicesDto?> GetAllServicesForTenant([FromQuery] GetServicesInDto m)
        {
            return await _operationFactory.New<GetServices>().ExecuteAsync(m);
        }


    }
}
