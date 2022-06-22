using Saanaa.Core.Meteor.Dto;

namespace Tenant.Operations.Favorite.Dtos
{
    public class FavoriteAddInDto : SaanaaDbInsertInDto
    {
        public int ModelId { get; set; }
        public int PersonId { get; set; }
        public int EntityId { get; set; }
    }
}
