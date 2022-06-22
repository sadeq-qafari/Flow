using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Operations.Database.Branch;
using Identity.Operations.Database.Branch.Commands;
using Identity.Operations.Database.Branch.Dtos;
using Identity.Operations.Database.Branch.Queries;
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
    public class BranchController : ControllerBase
    {

        private readonly OperationFactory _operationFactory;
        public BranchController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Identity.Branch.Read")]
        [HttpGet]
        public Task<QueryPage<BranchDto>?> Get([FromQuery] SaanaaDbQueryPageInDto m) =>
            _operationFactory.New<GetBranchPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] SaanaaDbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetBranchAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Identity.Branch.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Branch>?> GetByIds([FromQuery] SaanaaDbQueryByIdsInDto m) =>
            _operationFactory.New<GetBranchByIds>().ExecuteAsync(m);

        [NeedPermission("Identity.Branch.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] SaanaaDbQueryPageInDto m) =>
            File(await _operationFactory.New<GetBranchExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Branch.xlsx");


        [NeedPermission("Identity.Branch.Read")]
        [HttpGet("{id}")]
        public Task<Branch?> GetOne([FromRoute] SaanaaDbSelectInDto m) =>
            _operationFactory.New<GetBranch>().ExecuteAsync(m);

        [NeedPermission("Identity.Branch.Create")]
        [HttpPost]
        public Task<long> Add(BranchAddInDto m) =>
            _operationFactory.New<BranchAdd>().ExecuteAsync(m);

        [NeedPermission("Identity.Branch.Update")]
        [HttpPut]
        public Task<bool> Update(BranchUpdateInDto m) =>
            _operationFactory.New<BranchUpdate>().ExecuteAsync(m);

        [NeedPermission("Identity.Branch.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] SaanaaDbDeleteInDto m) =>
            _operationFactory.New<BranchRemove>().ExecuteAsync(m);
    }
}
