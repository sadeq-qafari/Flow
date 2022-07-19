using Core.Meteor;

namespace Tenant.Operations.Favorite.Queries
{
    public class GetFavorite : DbSelectAsync<Favorite?>
    {
        public GetFavorite() : base("[Tenant].[Favorite]")
        {
        }
    }
}