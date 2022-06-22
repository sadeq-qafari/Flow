using System.Threading.Tasks;
using Meteor.Operation.Db;
using Tenant.Operations.Transaction.Dtos;

namespace Tenant.Operations.Transaction.Queries
{
    public class GetTransactionCredit : DbOperationAsync<TransactionCreditInDto, decimal>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(@"EXECUTE Tenant.sp_TransactionCredit @PersonId = @PersonId, @TenantId = @TenantId")
                .ExecuteScalarAsync<decimal>();
        }
    }
}
