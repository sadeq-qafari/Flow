using Core.Meteor;
using Tenant.Operations.Banner.Dtos;

namespace Tenant.Operations.Banner.Commands
{
    public class BannerUpdate : DbUpdateAsync<BannerUpdateInDto>
    {
        public BannerUpdate() : base("[Tenant].[Banner]",
            @"[Title]=@Title,
					[Name]=@Name,
					[Image]=@Image,
					[Description]=@Description,
					[Link]=@Link,
					[IsLinkExternal]=@IsLinkExternal,
					[Size]=@Size,
					[Index]=@Index")
        {
        }
    }
}