using Saanaa.Core.Meteor;

namespace Tenant.Operations.Favorite.Commands
{
    public class FavoriteRemove : SaanaaDbDeleteAsync
    {
        public FavoriteRemove() : base("[Tenant].[Favorite]")
        {
        }
    }
}