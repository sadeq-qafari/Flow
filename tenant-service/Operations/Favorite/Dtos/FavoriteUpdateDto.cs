using Saanaa.Core.Meteor.Dto;

namespace Tenant.Operations.Favorite.Dtos
{
    public class FavoriteUpdateInDto : SaanaaDbUpdateInDto
    {
        public int PersonId { get; set; }
        public int EntityId { get; set; }
        public int ModelId { get; set; }

    }
}
