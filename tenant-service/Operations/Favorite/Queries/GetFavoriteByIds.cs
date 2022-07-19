using Core.Meteor;

namespace Tenant.Operations.Favorite.Queries
{
    public class GetFavoriteByIds : DbQueryByIds<Favorite>
    {
        public GetFavoriteByIds() : base("[Tenant].[Favorite]")
        {
        }
    }
}