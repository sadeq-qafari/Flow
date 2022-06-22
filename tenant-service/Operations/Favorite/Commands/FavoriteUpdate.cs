using Saanaa.Core.Meteor;
using Tenant.Operations.Favorite.Dtos;

namespace Tenant.Operations.Favorite.Commands
{
    public class FavoriteUpdate : SaanaaDbUpdateAsync<FavoriteUpdateInDto>
    {
        public FavoriteUpdate() : base("[Tenant].[Favorite]",
            @"[ModelId]=@ModelId,
                     [PersonId]=@PersonId,
                     [EntityId]=@EntityId")
        {
        }
    }
}