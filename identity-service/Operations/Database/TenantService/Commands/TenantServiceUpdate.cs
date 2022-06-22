using System.Threading.Tasks;
using Identity.Operations.Database.TenantService.Dtos;
using Meteor.Operation.Db;

namespace Identity.Operations.Database.TenantService.Commands
{
    public class TenantServiceUpdate : DbOperationAsync<TenantServiceUpdateInDto,bool>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(sql => sql.Update("[Identity].[TenantService]",
                    $"[ServiceId]=@ServiceId,[ExpireDate]=@ExpireDate, IsActive=@IsActive, ModifiedBy=@ModifiedBy, ModifiedAt=getdate()")
                .Where(x => x.Where("Id=@Id AND IsDeleted=0"))
                    ).ExecuteAsync() > 0;
        }
    }
}
