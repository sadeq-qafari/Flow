using System.Data;
using System.Threading.Tasks;
using Meteor.Operation.Db;
using Tenant.Operations.Branch.Dtos;

namespace Tenant.Operations.Branch.Commands
{
    public class BranchAdd : DbOperationAsync<BranchAddInDto, long>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await EnsureInTransactionAsync(async () =>
            {
                var branchId = await NewSql(sql => sql.InsertReturnId("[Identity].[Branch]",
                    @"[TenantId],[ParentId],[Title],[CityId],[GeoLocation],[Address],[PostalCode],[Phone]
                     ,[Fax],[IsActive],[IsDeleted],[CreatedBy]",
                    @"@TenantId,@ParentId,@Title,@CityId,@GeoLocation,@Address,@PostalCode,@Phone,@Fax,1,0,@CreatedBy")
                ).ExecuteScalarAsync<long>();
                var ledgerId = await NewSql(sql => sql.InsertReturnId("[Accounting].[Ledger]",
                        @"[Title] ,[IsDefault] ,[IsActive] ,[IsDeleted] ,[CreatedBy] ,[BranchId] ,[TenantId]",
                        @"@Title ,1 ,1 ,0 ,@CreatedBy ,@BranchId ,@TenantId"),
                    new
                    {
                        Input.Title,
                        Input.CreatedBy,
                        BranchId = branchId,
                        Input.TenantId
                    }
                ).ExecuteScalarAsync<long>();
                var financialYearId = await NewSql(sql => sql.InsertReturnId("[Accounting].[FinancialYear]",
                        @"[LedgerId] ,[Title] ,[FromDate] ,[ToDate] ,[IsOpen] ,[IsActive] ,[IsDeleted] ,[CreatedBy] ,[TenantId]",
                        @"@LedgerId ,@Title ,@FromDate ,@ToDate ,1 ,1 ,0 ,@CreatedBy ,@TenantId"),
                    new
                    {
                        LedgerId = ledgerId,
                        Title = Input.FinancialYearTitle,
                        FromDate = Input.FinancialYearFromDate,
                        ToDate = Input.FinancialYearToDate,
                        Input.CreatedBy,
                        Input.TenantId
                     }
                ).ExecuteScalarAsync<long>();
                return branchId;
            }, IsolationLevel.ReadCommitted);
        }
    }
}
