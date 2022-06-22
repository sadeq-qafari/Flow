using System.Threading.Tasks;
using Identity.Operations.Database.TenantUrl.Dtos;
using Meteor.Operation.Db;

namespace Identity.Operations.Database.TenantUrl.Commands
{
    public class TenantUrlUpdate : DbOperationAsync<TenantUrlUpdateInDto, bool>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(sql => sql.Update("[Identity].[TenantUrl]",
                @"[TypeLookup]=@TypeLookup,
					        [Url]=@Url,
					        [IsDefault]=@IsDefault,
                            [ModifiedAt]=GETDATE(),
                            [ModifiedBy]=@ModifiedBy,
                            [TenantId]=@TenantId").WhereThisId()).ExecuteAsync() > 0;
        }
    }
}
