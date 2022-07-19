using Identity.Operations.Database.ApiResource.Dtos;
using Core.Meteor;

namespace Identity.Operations.Database.ApiResource.Commands
{
    public class ApiResourceAdd : DbInsertAsync<ApiResourceAddInDto>
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

