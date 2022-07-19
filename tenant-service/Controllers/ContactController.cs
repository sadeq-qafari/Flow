using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;
using Tenant.Operations.Contact;
using Tenant.Operations.Contact.Commands;
using Tenant.Operations.Contact.Dto;
using Tenant.Operations.Contact.Queries;

namespace Tenant.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public ContactController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Tenant.Contact.Read")]
        [HttpGet]
        public Task<QueryPage<ContactDto>?> Get([FromQuery] DbQueryPageInDto m) =>
            _operationFactory.New<GetContactPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetContactAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Tenant.Contact.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Contact>?> GetByIds([FromQuery] DbQueryByIdsInDto m) =>
            _operationFactory.New<GetContactByIds>().ExecuteAsync(m);

        [NeedPermission("Tenant.Contact.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetContactExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Contact.xlsx");


        [NeedPermission("Tenant.Contact.Read")]
        [HttpGet("{id}")]
        public Task<Contact?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetContact>().ExecuteAsync(m);

        [NeedPermission("Tenant.Contact.Create")]
        [HttpPost]
        public Task<long> Add(AddContactInDto m) =>
            _operationFactory.New<AddContact>().ExecuteAsync(m);

        [NeedPermission("Tenant.Contact.Update")]
        [HttpPut]
        public Task<bool> Update(UpdateContactInDto m) =>
            _operationFactory.New<UpdateContact>().ExecuteAsync(m);

        [NeedPermission("Tenant.Contact.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<RemoveContact>().ExecuteAsync(m);


        // ========= Custom Actions:

        [NeedPermission(Policies = "backend")]
        [HttpGet("get")]
        public Task<IEnumerable<ContactsDto>?> GetEntityContacts([FromQuery] GetContactsInDto m) =>
            _operationFactory.New<GetContacts>().ExecuteAsync(m);

        [NeedPermission(Policies = "backend")]
        [HttpPost("set")]
        public Task<bool> GetEntityContacts([FromBody] SetContactsInDto m) =>
            _operationFactory.New<SetContacts>().ExecuteAsync(m);

    }
}
