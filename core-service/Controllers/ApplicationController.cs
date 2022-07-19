using System.Collections.Generic;
using System.Threading.Tasks;
using Core.AspNetCore.Security;
using Core.Meteor;
using Core.Meteor.Dto;
using Core.Operations.Application;
using Core.Operations.Application.Commands;
using Core.Operations.Application.Dtos;
using Core.Operations.Application.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly OperationFactory _operationFactory;

        public ApplicationController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Core.Application.Read")]
        [HttpGet]
        public Task<QueryPage<ApplicationDto>?> Get([FromQuery] DbQueryPageInDto m) =>
            _operationFactory.New<GetApplicationPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetApplicationAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Core.Application.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Application>?> GetByIds([FromQuery] DbQueryByIdsInDto m) =>
            _operationFactory.New<GetApplicationByIds>().ExecuteAsync(m);

        [NeedPermission("Core.Application.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetApplicationExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Application.xlsx");


        [NeedPermission("Core.Application.Read")]
        [HttpGet("{id}")]
        public Task<Application?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetApplication>().ExecuteAsync(m);

        [NeedPermission("Core.Application.Create")]
        [HttpPost]
        public Task<long> Add(ApplicationAddInDto m) =>
            _operationFactory.New<ApplicationAdd>().ExecuteAsync(m);

        [NeedPermission("Core.Application.Update")]
        [HttpPut]
        public Task<bool> Update(ApplicationUpdateInDto m) =>
            _operationFactory.New<ApplicationUpdate>().ExecuteAsync(m);

        [NeedPermission("Core.Application.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<ApplicationRemove>().ExecuteAsync(m);

        // ============== Custom Actions:

        [HttpGet("terms")]
        public Task<string?> GetApplicationTerms()
        {
            var applicationId = SqTenants.GetTenant(HttpContext)!.ApplicationId;
            return _operationFactory.New<GetApplicationTerms>().ExecuteAsync(applicationId);
        }
    }
}
