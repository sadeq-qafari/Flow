using Identity.Operations.Database.ApiScope.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.ApiScope.Commands
{
    public class ApiScopeAdd : SaanaaDbInsertAsync<ApiScopeAddInDto>
    {
        public ApiScopeAdd() : base("[Identity].[ApiScope]",
            @"[Name],
						[DisplayName],
						[Description],
						[Required],
						[Emphasize],
						[ShowInDiscoveryDocument],
						[ApiResourceId],
						[Claims],
						[Properties]",
            @"@Name,
						@DisplayName,
						@Description,
						@Required,
						@Emphasize,
						@ShowInDiscoveryDocument,
						@ApiResourceId,
						@Claims,
						@Properties")
        {
        }
    }
}

