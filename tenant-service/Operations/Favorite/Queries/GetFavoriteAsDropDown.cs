using Saanaa.Core.Meteor;

namespace Tenant.Operations.Favorite.Queries
{
    public class GetFavoriteAsDropDown : SaanaaDbQueryAsDropDown<Favorite>
    {
        public GetFavoriteAsDropDown() : base("[Tenant].[Favorite]")
        {
        }
    }
}
