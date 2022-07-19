using Core.Meteor.Dto;

namespace Tenant.Operations.Favorite.Dtos
{
    public class FavoriteUpdateInDto : DbUpdateInDto
    {
        public int PersonId { get; set; }
        public int EntityId { get; set; }
        public int ModelId { get; set; }

    }
}
