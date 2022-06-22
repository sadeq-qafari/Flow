using System.Data;
using System.Threading.Tasks;
using Identity.Operations.Database.Role.Dtos;
using Identity.Operations.Database.RolePermission.Commands;
using Identity.Operations.Database.RolePermission.Dtos;
using Meteor.Operation.Db;

namespace Identity.Operations.Database.Role.Commands
{
    public class RoleAdd : DbOperationAsync<RoleAddInDto, long>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await EnsureInTransactionAsync(async () =>
            {
                var roleId = await NewSql(sql => sql.InsertReturnId("[Identity].[Role]",
                    @"[Title], [Description], [ServiceId], [IsActive], [CreatedBy], [TenantId]",
                    @"@Title, @Description, @ServiceId, @IsActive, @CreatedBy, @TenantId")).ExecuteScalarAsync<long>();

                await OperationFactory!.New<RolePermissionMerge>().ExecuteAsync(new RolePermissionMergeInDto
                {
                    PermissionCheckList = Input.PermissionCheckList,
                    RoleId = (int)roleId,
                    ActionBy = Input.CreatedBy
                });
                return roleId;
            }, IsolationLevel.ReadCommitted);
        }
    }
}
