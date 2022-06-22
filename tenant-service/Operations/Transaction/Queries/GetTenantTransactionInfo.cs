using System.Threading.Tasks;
using Meteor.Operation.Db;
using Tenant.Operations.Transaction.Dtos;

namespace Tenant.Operations.Transaction.Queries
{
    public class GetTenantTransactionInfo : DbOperationAsync<int, TenantTransactionInfoDto>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(@"EXECUTE Tenant.sp_TenantTransactionInfo @TransactionId = @TransactionId",
                    new { TransactionId = Input })
                .QueryFirstOrDefaultAsync<TenantTransactionInfoDto>();
        }
    }
}