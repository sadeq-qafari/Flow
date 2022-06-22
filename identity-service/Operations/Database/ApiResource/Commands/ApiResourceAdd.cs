using Identity.Operations.Database.ApiResource.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.ApiResource.Commands
{
    public class ApiResourceAdd : SaanaaDbInsertAsync<ApiResourceAddInDto>
    {
        public ApiResourceAdd() : base("[Identity].[ApiResource]",
            @"[Enabled],
						[Name],
						[DisplayName],
						[Description],
						[Created],
						[Updated],
						[LastAccessed],
						[NonEditable],
						[Properties],
						[Claims],
						[Scopes],
						[Secrets]",
            @"@Enabled,
						@Name,
						@DisplayName,
						@Description,
						@Created,
						@Updated,
						@LastAccessed,
						@NonEditable,
						@Properties,
						@Claims,
						@Scopes,
						@Secrets")
        {
        }
    }
}

