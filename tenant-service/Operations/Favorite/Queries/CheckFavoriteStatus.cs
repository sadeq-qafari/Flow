using System.Threading.Tasks;
using Meteor.Operation.Db;
using Meteor.Utils;
using Core.Meteor;
using Tenant.Operations.Favorite.Dtos;

namespace Tenant.Operations.Favorite.Queries
{
    public class CheckFavoriteStatus : DbOperationAsync<FavoriteCheckInDto, bool>
    {
        protected override async Task ExecutionAsync()
        {
            var modelId = SqServices.GetModel(Input.ServiceName, Input.ModelName)?.Id
                          ?? throw Errors.InvalidInput("model_not_found");

            Output = await NewSql(@"EXECUTE Tenant.sp_FavoriteCheck @ModelId = @ModelId
                                      ,@EntityId = @EntityId
                                      ,@ActionBy = @ActionBy
                                      ,@TenantId = @TenantId",
                    new {ModelId = modelId, Input.EntityId, Input.ActionBy, Input.TenantId})
                .QueryFirstOrDefaultAsync<bool>();
        }
    }
}