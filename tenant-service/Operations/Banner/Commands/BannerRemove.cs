using Saanaa.Core.Meteor;

namespace Tenant.Operations.Banner.Commands
{
    public class BannerRemove : SaanaaDbDeleteAsync
    {
        public BannerRemove() : base("[Tenant].[Banner]")
        {
        }
    }
}