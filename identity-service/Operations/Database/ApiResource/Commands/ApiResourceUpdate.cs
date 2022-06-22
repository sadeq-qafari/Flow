using Identity.Operations.Database.ApiResource.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.ApiResource.Commands
{
    public class ApiResourceUpdate : SaanaaDbUpdateAsync<ApiResourceUpdateInDto>
    {
        public ApiResourceUpdate() : base("[Identity].[ApiResource]",
            @"[Enabled]=@Enabled,
					[Name]=@Name,
					[DisplayName]=@DisplayName,
					[Description]=@Description,
					[Created]=@Created,
					[Updated]=@Updated,
					[LastAccessed]=@LastAccessed,
					[NonEditable]=@NonEditable,
					[Properties]=@Properties,
					[Claims]=@Claims,
					[Scopes]=@Scopes,
					[Secrets]=@Secrets")
        {
        }
    }
}