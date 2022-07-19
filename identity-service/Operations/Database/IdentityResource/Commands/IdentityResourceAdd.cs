using Identity.Operations.Database.IdentityResource.Dtos;
using Core.Meteor;

namespace Identity.Operations.Database.IdentityResource.Commands
{
    public class IdentityResourceAdd : DbInsertAsync<IdentityResourceAddInDto>
    {
        public IdentityResourceAdd() : base("[Identity].[IdentityResource]",
            @"[Enabled],
						[Name],
						[DisplayName],
						[Description],
						[Required],
						[Emphasize],
						[ShowInDiscoveryDocument],
						[Created],
						[Updated],
						[NonEditable],
						[Claims],
						[Properties]",
            @"@Enabled,
						@Name,
						@DisplayName,
						@Description,
						@Required,
						@Emphasize,
						@ShowInDiscoveryDocument,
						@Created,
						@Updated,
						@NonEditable,
						@Claims,
						@Properties")
        {
        }
    }
}

