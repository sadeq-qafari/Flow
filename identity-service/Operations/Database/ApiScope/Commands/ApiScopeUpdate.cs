using Identity.Operations.Database.ApiScope.Dtos;
using Core.Meteor;

namespace Identity.Operations.Database.ApiScope.Commands
{
    public class ApiScopeUpdate : DbUpdateAsync<ApiScopeUpdateInDto>
    {
        public ApiScopeUpdate() : base("[Identity].[ApiScope]",
            @"[Name]=@Name,
					[DisplayName]=@DisplayName,
					[Description]=@Description,
					[Required]=@Required,
					[Emphasize]=@Emphasize,
					[ShowInDiscoveryDocument]=@ShowInDiscoveryDocument,
					[ApiResourceId]=@ApiResourceId,
					[Claims]=@Claims,
					[Properties]=@Properties")
        {
        }
    }
}