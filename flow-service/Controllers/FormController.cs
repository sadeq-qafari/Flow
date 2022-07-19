using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.AspNetCore.Security;
using Core.Meteor;
using Core.Meteor.Dto;
using Flow.Core;
using Flow.Dto;
using Flow.Operations.Form;
using Flow.Operations.Form.Commands;
using Flow.Operations.Form.Dtos;
using Flow.Operations.Form.Queries;
using Meteor.AspCore.Filters;
using Meteor.Database;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class FormController : ControllerBase
    {
        private readonly OperationFactory _operationFactory;
        private readonly LazyDbConnection _lazyDbConnection;

        public FormController(OperationFactory operationFactory, LazyDbConnection lazyDbConnection)
        {
            _operationFactory = operationFactory;
            _lazyDbConnection = lazyDbConnection;
        }

        [NeedPermission("Flow.Form.Read")]
        [HttpGet]
        public Task<QueryPage<FormDto>?> Get([FromQuery] DbQueryPageInDto m) =>
            _operationFactory.New<GetFormPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetFormAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Flow.Form.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Form>?> GetByIds([FromQuery] DbQueryByIdsInDto m) =>
            _operationFactory.New<GetFormByIds>().ExecuteAsync(m);

        [NeedPermission("Flow.Form.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetFormExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Form.xlsx");

        // [NeedPermission("Flow.Form.Read")]
        // [HttpGet("{id}")]
        // public Task<Form?> GetOne([FromRoute] DbSelectInDto m) =>
        //     _operationFactory.New<GetForm>().ExecuteAsync(m);

        [NeedPermission("Flow.Form.Create")]
        [HttpPost]
        public Task<long> Add(FormAddInDto m) =>
            _operationFactory.New<FormAdd>().ExecuteAsync(m);

        [NeedPermission("Flow.Form.Update")]
        [HttpPut]
        public Task<bool> Update(FormUpdateInDto m) =>
            _operationFactory.New<FormUpdate>().ExecuteAsync(m);

        // ======= Custom Actions:

        [NeedPermission("Flow.Form.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<FormRemove>().ExecuteAsync(m);

        [NeedPermission("Flow.Form.Create")]
        [HttpPost("upsert")]
        public async Task<int> FormUpsert([FromBody] FormUpsertInDto m)
        {
            var res = await _operationFactory.New<FormUpsert>().ExecuteAsync(m);
            await SaanaaForms.Reload(_lazyDbConnection);
            return res;
        }

        [HttpGet("reload")]
        public async Task<SaanaaFormsDto> ReloadForms()
        {
            await SaanaaForms.Reload(_lazyDbConnection);
            var tenantId = SqTenants.GetTenant(HttpContext)!.Id;
            return GetSaanaaFormsDto(tenantId);
        }

        [HttpGet("config")]
        public async Task<SaanaaFormsDto?> GetForms(long? version)
        {
            var requestedVersion = version.GetValueOrDefault(0);
            var tenantId = SqTenants.GetTenant(HttpContext)!.Id;
            if (requestedVersion <= 0 || requestedVersion != SaanaaForms.LatestVersion)
                return SaanaaForms.Forms.Count == 0
                    ? await ReloadForms()
                    : GetSaanaaFormsDto(tenantId);

            return null;
        }

        private static SaanaaFormsDto GetSaanaaFormsDto(int tenantId)
        {
            return new SaanaaFormsDto
            {
                Forms = SaanaaForms.GetForms(tenantId),
                Version = SaanaaForms.LatestVersion
            };
        }

        [HttpGet("info")]
        public Task<FormInfoDto?> GetFormInfo([FromQuery] int formId) =>
            _operationFactory.New<GetFormInfo>().ExecuteAsync(formId);

        [NeedPermission("Flow.Form.Read")]
        [HttpGet("read/{formName}")]
        public Task<object?> ReadForm([FromRoute] string formName, [FromQuery] ReadFormInDto m)
        {
            m.FormName = formName;
            return _operationFactory.New<ReadForm>().ExecuteAsync(m);
        }

        [NeedPermission("Flow.Form.Create")]
        [HttpPost("submit/{formName}")]
        public Task<SubmitFormDto?> AddData([FromRoute] string formName, [FromBody] SubmitFormInDto m)
        {
            m.FormName = formName;
            return _operationFactory.New<SubmitForm>().ExecuteAsync(m);
        }

        [NeedPermission]
        [HttpGet("{formName}")]
        public Task<QueryPage<object>?> GetFormGrid([FromRoute] string formName, [FromQuery] GetFormGridInDto m)
        {
            m.FormName = formName;
            return _operationFactory.New<GetFormGrid>().ExecuteAsync(m);
        }

        [NeedPermission]
        [HttpGet("excel/{formName}")]
        public async Task<IActionResult> GetFormGridExcel([FromRoute] string formName, [FromQuery] GetFormGridInDto m)
        {
            m.FormName = formName;
            return File(await _operationFactory.New<GetFormGridExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{formName}.xlsx");
        }

        [NeedPermission("Flow.Form.Read")]
        [HttpGet("dropdown/{formName}")]
        public Task<IEnumerable<object>?> FormDropdown([FromRoute] string formName, [FromQuery] FormDropDownInDto m)
        {
            m.FormName = formName;
            return _operationFactory.New<GetFormDropDown>().ExecuteAsync(m);
        }

        [NeedPermission("Flow.Form.Read")]
        [HttpGet("multiDropdown/{formName}")]
        public Task<IEnumerable<object>?> FormMultiDropdown([FromRoute] string formName, [FromQuery] FormMultiDropDownInDto m)
        {
            m.FormName = formName;
            return _operationFactory.New<GetFormMultiDropDown>().ExecuteAsync(m);
        }

        [NeedPermission("Flow.Form.Read")]
        [HttpGet("search")]
        public Task<Dictionary<string, IEnumerable<object>>?> SearchForms([FromQuery] SearchFormsInDto m)
        {
            return _operationFactory.New<SearchForms>().ExecuteAsync(m);
        }

        [NeedPermission]
        [HttpPost("import")]
        public Task<bool> ImportFormData([FromForm] ImportFormDataInDto m)
        {
            m.File = Request.Form.Files.FirstOrDefault();
            return _operationFactory.New<ImportFormData>().ExecuteAsync(m);
        }
    }
}
