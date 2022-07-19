using Core.Meteor;

namespace Tenant.Operations.Favorite.Commands
{
    public class FavoriteRemove : DbDeleteAsync
    {
        public FavoriteRemove() : base("[Tenant].[Favorite]")
        {
        }
    }
}