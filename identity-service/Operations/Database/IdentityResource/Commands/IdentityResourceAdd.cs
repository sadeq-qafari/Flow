using Identity.Operations.Database.IdentityResource.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.IdentityResource.Commands
{
    public class IdentityResourceAdd : SaanaaDbInsertAsync<IdentityResourceAddInDto>
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

