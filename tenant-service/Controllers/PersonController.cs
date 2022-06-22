using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Saanaa.Core.AspNetCore.Security;
using Saanaa.Core.Meteor.Dto;
using Tenant.Operations.Person;
using Tenant.Operations.Person.Commands;
using Tenant.Operations.Person.Dto;
using Tenant.Operations.Person.Queries;

namespace Tenant.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public PersonController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Tenant.Person.Read")]
        [HttpGet]
        public Task<QueryPage<PersonDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetPersonPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetPersonAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Tenant.Person.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Person>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetPersonByIds>().ExecuteAsync(m);

        [NeedPermission("Tenant.Person.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetPersonExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Person.xlsx");


        [NeedPermission("Tenant.Person.Read")]
        [HttpGet("{id}")]
        public Task<Person?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetPerson>().ExecuteAsync(m);

        [NeedPermission("Tenant.Person.Create")]
        [HttpPost]
        public Task<long> Add(AddPersonInDto m) =>
            _operationFactory.New<AddPerson>().ExecuteAsync(m);

        [NeedPermission("Tenant.Person.Update")]
        [HttpPut]
        public Task<bool> Update(UpdatePersonInDto m) =>
            _operationFactory.New<UpdatePerson>().ExecuteAsync(m);

        [NeedPermission("Tenant.Person.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<RemovePerson>().ExecuteAsync(m);
    }
}
