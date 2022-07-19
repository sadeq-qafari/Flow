using Core.Meteor;
using Tenant.Operations.Favorite.Dtos;

namespace Tenant.Operations.Favorite.Commands
{
    public class FavoriteAdd : DbInsertAsync<FavoriteAddInDto>
    {
        public FavoriteAdd() : base("[Tenant].[Favorite]",
            @"[ModelId],
                         [PersonId],
                         [EntityId]",
            @"@ModelId,
                         @PersonId,
                         @EntityId")
        {
        }
    }
}