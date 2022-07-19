using System.Threading.Tasks;
using Meteor.Operation.Db;
using Meteor.Utils;
using Core.Meteor;
using Tenant.Operations.Favorite.Dtos;

namespace Tenant.Operations.Favorite.Commands
{
    public class FavoriteToggle : DbOperationAsync<FavoriteToggleInDto, bool>,INeedLog,IHaveTableName
    {
        public string TableName { get; set; } = "[Tenant].[Favorite]";
        protected override async Task ExecutionAsync()
        {
            var modelId = SqServices.GetModel(Input.ServiceName, Input.ModelName)?.Id
                          ?? throw Errors.InvalidInput("model_not_found");

            Output = await NewSql(@"EXECUTE Tenant.sp_FavoriteEntityToggle @ModelId = @ModelId
                                      ,@EntityId = @EntityId
                                      ,@ActionBy = @ActionBy
                                      ,@TenantId = @TenantId",
                    new {ModelId = modelId, Input.EntityId, Input.ActionBy, Input.TenantId})
                .ExecuteAsync()
                .ValidateDatabaseAffectedRows() > 0;
        }

    }
}
