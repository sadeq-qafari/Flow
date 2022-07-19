using Core.Meteor.Dto;

namespace Tenant.Operations.Favorite.Dtos
{
    public class FavoriteAddInDto : DbInsertInDto
    {
        public int ModelId { get; set; }
        public int PersonId { get; set; }
        public int EntityId { get; set; }
    }
}
