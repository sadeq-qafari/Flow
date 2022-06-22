using Saanaa.Core.Meteor;

namespace Tenant.Operations.Favorite.Queries
{
    public class GetFavoriteExcel : SaanaaDbQueryExcel<Favorite>
    {
        public GetFavoriteExcel() : base("[Tenant].[Favorite]")
        {
        }
    }
}