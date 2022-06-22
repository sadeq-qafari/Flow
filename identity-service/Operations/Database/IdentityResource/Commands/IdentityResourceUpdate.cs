using Identity.Operations.Database.IdentityResource.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.IdentityResource.Commands
{
    public class IdentityResourceUpdate : SaanaaDbUpdateAsync<IdentityResourceUpdateInDto>
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