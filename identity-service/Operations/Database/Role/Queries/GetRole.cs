using System.Threading.Tasks;
using Identity.Operations.Database.Role.Dtos;
using Identity.Operations.Database.RolePermission.Queries;
using Meteor.Operation.Db;
using Saanaa.Core.Meteor.Dto;

namespace Identity.Operations.Database.Role.Queries
{
    public class GetRole : DbOperationAsync<SaanaaDbSelectInDto, RoleDto>
    {
        protected override async Task ExecutionAsync()
        {
            var role = await NewSql(sql => sql
                    .Select("[Identity].[Role]")
                    .Where("Id=@Id AND IsDeleted=0"))
                .QueryFirstOrDefaultAsync<RoleDto?>() ?? new RoleDto();
            role.PermissionCheckList = (await OperationFactory!.New<GetRolePermissions>().ExecuteAsync(Input))!;
            Output = role;
        }
    }
}
