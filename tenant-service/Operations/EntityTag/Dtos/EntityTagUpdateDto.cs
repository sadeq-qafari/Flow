using Saanaa.Core.Meteor.Dto;

namespace Tenant.Operations.EntityTag.Dtos
{
    public class EntityTagUpdateInDto : SaanaaDbUpdateInDto
    {
        public int ModelId { get; set; }
        public int EntityId { get; set; }
        public int TagId { get; set; }

    }
}
