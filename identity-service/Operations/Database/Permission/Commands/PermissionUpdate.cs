using Identity.Operations.Database.Permission.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Permission.Commands
{
    public class PermissionUpdate : SaanaaDbUpdateAsync<PermissionUpdateInDto>
    {
        public PermissionUpdate() : base("[Identity].[Permission]",
            @"[Name]=@Name,
					[Title]=@Title,
					[TypeLookup]=@TypeLookup")
        {
        }
    }
}
