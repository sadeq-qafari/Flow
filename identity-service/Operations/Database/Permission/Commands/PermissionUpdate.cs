using Identity.Operations.Database.Permission.Dtos;
using Core.Meteor;

namespace Identity.Operations.Database.Permission.Commands
{
    public class PermissionUpdate : DbUpdateAsync<PermissionUpdateInDto>
    {
        public PermissionUpdate() : base("[Identity].[Permission]",
            @"[Name]=@Name,
					[Title]=@Title,
					[TypeLookup]=@TypeLookup")
        {
        }
    }
}
