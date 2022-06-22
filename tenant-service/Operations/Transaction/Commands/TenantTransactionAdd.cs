using System.Threading.Tasks;
using Meteor.Operation.Db;
using Tenant.Operations.Transaction.Dtos;

namespace Tenant.Operations.Transaction.Commands
{
    public class TenantTransactionAdd : DbOperationAsync<TenantTransactionAddInDto, bool>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(@"EXECUTE Tenant.sp_TenantTransactionAdd @Code = @Code
                                      ,@Amount = @Amount
                                      ,@GiftAmount = @GiftAmount
                                      ,@TaxAmount = @TaxAmount
                                      ,@TypeLookup = @TypeLookup
                                      ,@Description = @Description
                                      ,@ActionBy = @ActionBy
                                      ,@TenantId = @TenantId").ExecuteAsync() > 0;
        }
    }
}
