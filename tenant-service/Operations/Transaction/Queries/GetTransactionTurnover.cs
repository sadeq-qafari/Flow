using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.Operation.Db;
using Tenant.Operations.Transaction.Dtos;

namespace Tenant.Operations.Transaction.Queries
{
    public class GetTransactionTurnover : DbOperationAsync<TransactionCreditInDto, IEnumerable<TransactionTurnoverDto>>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(@"EXECUTE Tenant.sp_TransactionTurnover @PersonId = @PersonId, @TenantId = @TenantId")
                .QueryAsync<TransactionTurnoverDto>();
        }
    }
}
