using System.Threading.Tasks;
using Identity.Operations.Database.TenantService.Dtos;
using Meteor.Operation.Db;

namespace Identity.Operations.Database.TenantService.Commands
{
    public class TenantServiceAdd : DbOperationAsync<TenantServiceAddInDto, long>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(sql => sql.InsertReturnId("[Identity].[TenantService]",
                    @"[ServiceId], [ExpireDate], [TenantId], [IsActive], [CreatedBy]",
                    @"@ServiceId, @ExpireDate, @TenantId, @IsActive, @CreatedBy"))
                .ExecuteScalarAsync<long>();
        }
    }
}
