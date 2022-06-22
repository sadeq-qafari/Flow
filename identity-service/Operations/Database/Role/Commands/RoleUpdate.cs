using System.Data;
using System.Threading.Tasks;
using Identity.Operations.Database.Role.Dtos;
using Identity.Operations.Database.RolePermission.Commands;
using Identity.Operations.Database.RolePermission.Dtos;
using Meteor.Operation.Db;
using Meteor.Utils;

namespace Identity.Operations.Database.Role.Commands
{
    public class RoleUpdate : DbOperationAsync<RoleUpdateInDto, bool>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await EnsureInTransactionAsync(async () =>
            {
                var roleId = await NewSql(sql => sql.Update("[Identity].[Role]",
                        @"[Title]=@Title, [Description]=@Description, [ServiceId]=@ServiceId, [ModifiedBy]=@ModifiedBy")
                    .Where("Id = @Id")
                ).ExecuteAsync().ValidateDatabaseAffectedRows() > 0;

                await OperationFactory!.New<RolePermissionMerge>().ExecuteAsync(new RolePermissionMergeInDto
                {
                    PermissionCheckList = Input.PermissionCheckList,
                    RoleId = Input.Id,
                    ActionBy = (int)Input.ModifiedBy!
                });
                return roleId;
            }, IsolationLevel.ReadCommitted);
        }
    }
}
