using Identity.Operations.Database.TenantUser.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantUser.Commands
{
    public class TenantUserAdd : SaanaaDbInsertAsync<TenantUserAddInDto>
    {
        public TenantUserAdd() : base("[Identity].[TenantUser]",
            @"[BranchId],
						[UserId],
						[IsBanned],
						[IsDefault]",
            @"@BranchId,
						@UserId,
						@IsBanned,
						@IsDefault")
        {
        }
    }
}

