using Identity.Operations.Database.ApiResource.Dtos;
using Core.Meteor;

namespace Identity.Operations.Database.ApiResource.Commands
{
    public class ApiResourceUpdate : DbUpdateAsync<ApiResourceUpdateInDto>
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