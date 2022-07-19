using Core.Meteor;

namespace Tenant.Operations.Banner.Commands
{
    public class BannerRemove : DbDeleteAsync
    {
        public BannerRemove() : base("[Tenant].[Banner]")
        {
        }
    }
}