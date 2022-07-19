using Core.Meteor;
using Tenant.Operations.Banner.Dtos;

namespace Tenant.Operations.Banner.Commands
{
    public class BannerAdd : DbInsertAsync<BannerAddInDto>
    {
        public BannerAdd() : base("[Tenant].[Banner]",
            @"[Title],
						[Name],
						[Image],
						[Description],
						[Link],
						[IsLinkExternal],
						[Size],
						[Index]",
            @"@Title,
						@Name,
						@Image,
						@Description,
						@Link,
						@IsLinkExternal,
						@Size,
						@Index")
        {
        }
    }
}

