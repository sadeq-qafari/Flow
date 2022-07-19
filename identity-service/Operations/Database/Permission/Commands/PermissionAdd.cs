using Identity.Operations.Database.Permission.Dtos;
using Core.Meteor;

namespace Identity.Operations.Database.Permission.Commands
{
    public class PermissionAdd : DbInsertAsync<PermissionAddInDto>
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

