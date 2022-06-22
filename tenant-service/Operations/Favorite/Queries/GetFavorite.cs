using Saanaa.Core.Meteor;

namespace Tenant.Operations.Favorite.Queries
{
    public class GetFavorite : SaanaaDbSelectAsync<Favorite?>
    {
        public GetFavorite() : base("[Tenant].[Favorite]")
        {
        }
    }
}