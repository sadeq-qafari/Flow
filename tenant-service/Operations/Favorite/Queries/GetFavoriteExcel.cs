using Core.Meteor;

namespace Tenant.Operations.Favorite.Queries
{
    public class GetFavoriteExcel : DbQueryExcel<Favorite>
    {
        public GetFavoriteExcel() : base("[Tenant].[Favorite]")
        {
        }
    }
}