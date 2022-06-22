using Identity.Operations.Database.Permission.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Permission.Commands
{
    public class PermissionAdd : SaanaaDbInsertAsync<PermissionAddInDto>
    {
        public PermissionAdd() : base("[Identity].[Permission]",
            @"[Name],
						[Title],
						[TypeLookup]",
            @"@Name,
						@Title,
						@TypeLookup")
        {
        }
    }
}

