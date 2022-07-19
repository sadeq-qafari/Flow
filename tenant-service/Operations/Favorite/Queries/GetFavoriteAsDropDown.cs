using Core.Meteor;

namespace Tenant.Operations.Favorite.Queries
{
    public class GetFavoriteAsDropDown : DbQueryAsDropDown<Favorite>
    {
        public GetFavoriteAsDropDown() : base("[Tenant].[Favorite]")
        {
        }
    }
}
