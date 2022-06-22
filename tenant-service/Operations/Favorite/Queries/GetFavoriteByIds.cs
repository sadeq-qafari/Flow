using Saanaa.Core.Meteor;

namespace Tenant.Operations.Favorite.Queries
{
    public class GetFavoriteByIds : SaanaaDbQueryByIds<Favorite>
    {
        public GetFavoriteByIds() : base("[Tenant].[Favorite]")
        {
        }
    }
}