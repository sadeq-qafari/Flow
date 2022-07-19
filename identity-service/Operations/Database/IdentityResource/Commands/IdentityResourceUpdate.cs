using Identity.Operations.Database.IdentityResource.Dtos;
using Core.Meteor;

namespace Identity.Operations.Database.IdentityResource.Commands
{
    public class IdentityResourceUpdate : DbUpdateAsync<IdentityResourceUpdateInDto>
    {
        public IdentityResourceUpdate() : base("[Identity].[IdentityResource]",
            @"[Enabled]=@Enabled,
					[Name]=@Name,
					[DisplayName]=@DisplayName,
					[Description]=@Description,
					[Required]=@Required,
					[Emphasize]=@Emphasize,
					[ShowInDiscoveryDocument]=@ShowInDiscoveryDocument,
					[Created]=@Created,
					[Updated]=@Updated,
					[NonEditable]=@NonEditable,
					[Claims]=@Claims,
					[Properties]=@Properties")
        {
        }
    }
}