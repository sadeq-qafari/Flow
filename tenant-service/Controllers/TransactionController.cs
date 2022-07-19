using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Meteor.Utils;
using Microsoft.AspNetCore.Mvc;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;
using Tenant.Operations.Transaction;
using Tenant.Operations.Transaction.Commands;
using Tenant.Operations.Transaction.Dtos;
using Tenant.Operations.Transaction.Queries;

namespace Tenant.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly OperationFactory _operationFactory;

        public TransactionController(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [NeedPermission("Tenant.Transaction.Read")]
        [HttpGet]
        public Task<QueryPage<TransactionDto>?> Get([FromQuery] DbQueryPageInDto m) =>
            _operationFactory.New<GetTransactionPage>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet("dropdown")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) =>
            _operationFactory.New<GetTransactionAsDropDown>().ExecuteAsync(m);

        [NeedPermission("Tenant.Transaction.Read")]
        [HttpGet("ids")]
        public Task<IEnumerable<Transaction>?> GetByIds([FromQuery] DbQueryByIdsInDto m) =>
            _operationFactory.New<GetTransactionByIds>().ExecuteAsync(m);

        [NeedPermission("Tenant.Transaction.Read")]
        [HttpGet("excel")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<GetTransactionExcel>().ExecuteAsync(m),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Transaction.xlsx");


        [NeedPermission("Tenant.Transaction.Read")]
        [HttpGet("{id}")]
        public Task<Transaction?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<GetTransaction>().ExecuteAsync(m);

        [NeedPermission(Policies = "backend")]
        [HttpPost]
        public Task<long> Add(TransactionAddInDto m) =>
            _operationFactory.New<TransactionAdd>().ExecuteAsync(m);

        [NeedPermission("Tenant.Transaction.Update")]
        [HttpPut]
        public Task<bool> Update(TransactionUpdateInDto m) =>
            _operationFactory.New<TransactionUpdate>().ExecuteAsync(m);

        [NeedPermission("Tenant.Transaction.Delete")]
        [HttpDelete("{id}")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<TransactionRemove>().ExecuteAsync(m);

        // ============= Custom Actions:

        [NeedPermission]
        [HttpGet("tenantTransactionInfo")]
        public Task<TenantTransactionInfoDto?> GetTenantTransactionInfo([FromQuery] int id) =>
            _operationFactory.New<GetTenantTransactionInfo>().ExecuteAsync(id);

        [NeedPermission]
        [HttpGet("transactionSummary")]
        public Task<TenantTransactionSummaryDto?> GetTenantTransactionSummary()
        {
            var tenantId = HttpContext.UserInfo()!.TenantId;
            return _operationFactory.New<GetTenantTransactionSummary>().ExecuteAsync(tenantId);
        }

        [NeedPermission]
        [HttpGet("credit")]
        public Task<decimal> GetUserCredit([FromQuery] TransactionCreditInDto m)
        {
            m.PersonId = HttpContext.UserInfo()?.Id ?? throw Errors.InvalidInput("invalid_person_id");
            return _operationFactory.New<GetTransactionCredit>().ExecuteAsync(m);
        }

        [NeedPermission(Policies = "admin")]
        [HttpGet("credit/{personId}")]
        public Task<decimal> GetCredit([FromRoute] TransactionCreditInDto m)
        {
            if (m.PersonId <= 0)
                throw Errors.InvalidInput("invalid_person_id");
            return _operationFactory.New<GetTransactionCredit>().ExecuteAsync(m);
        }

        [NeedPermission]
        [HttpGet("turnover")]
        public Task<IEnumerable<TransactionTurnoverDto>?> GetUserTurnover([FromQuery] TransactionCreditInDto m)
        {
            m.PersonId = HttpContext.UserInfo()?.Id ?? throw Errors.InvalidInput("invalid_person_id");
            return _operationFactory.New<GetTransactionTurnover>().ExecuteAsync(m);
        }

        [NeedPermission(Policies = "admin")]
        [HttpGet("turnover/{personId}")]
        public Task<IEnumerable<TransactionTurnoverDto>?> GetTurnover([FromRoute] TransactionCreditInDto m)
        {
            if (m.PersonId <= 0)
                throw Errors.InvalidInput("invalid_person_id");
            return _operationFactory.New<GetTransactionTurnover>().ExecuteAsync(m);
        }
    }
}
