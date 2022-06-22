using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Operations.Database.Client;
using Identity.Operations.Database.Client.Commands;
using Identity.Operations.Database.Client.Dtos;
using Identity.Operations.Database.Client.Queries;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using Saanaa.Core.AspNetCore.Security;
using Saanaa.Core.Meteor.Dto;

namespace Identity.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public ClientController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Identity.Client.Read")]
        [HttpGet]
        public Task<QueryPage<ClientDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetClientPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetClientAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Identity.Client.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Client>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetClientByIds>().ExecuteAsync(m);

        [NeedPermission("Identity.Client.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetClientExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Client.xlsx");

        //
        // [NeedPermission("Identity.Client.Read")]
        // [HttpGet("{id}")]
        // public Task<Client?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
        //     _operationFactory.New<GetClient>().ExecuteAsync(m);

        [NeedPermission("Identity.Client.Create")]
        [HttpPost]
        public Task<long> Add(ClientAddInDto m) =>
            _operationFactory.New<ClientAdd>().ExecuteAsync(m);

        [NeedPermission("Identity.Client.Update")]
        [HttpPut]
        public Task<bool> Update(ClientUpdateInDto m) =>
            _operationFactory.New<ClientUpdate>().ExecuteAsync(m);

        [NeedPermission("Identity.Client.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<ClientRemove>().ExecuteAsync(m);
    }
}
