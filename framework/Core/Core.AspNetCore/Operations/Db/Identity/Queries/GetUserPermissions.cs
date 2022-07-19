using System.Threading.Tasks;
using Core.AspNetCore.Operations.Db.Identity.Dto;
using Core.Meteor;
using Meteor.Operation;
using Meteor.Utils;

namespace Core.AspNetCore.Operations.Db.Identity.Queries
{
    public class GetUserPermissions : OperationAsync<GetUserPermissionsInDto, PermissionStore>
    {
        protected override async Task ExecutionAsync()
        {
            var apiClient = OperationFactory!.GetService<ApiClient>()
                            ?? throw Errors.InternalError("apiClient_not_registered");
            Output = (await apiClient!.GetAsync<OperationResult<PermissionStore>>("Identity", "User",
                $"permissions?branchId={Input.BranchId}&tenantId={Input.TenantId}&actionBy={Input.ActionBy}"))?.Result;
        }
    }
}
