using Saanaa.Core.Meteor.Dto;

namespace Tenant.Operations.PricingItem.Dtos
{
    public class PricingItemUpdateInDto : SaanaaDbUpdateInDto
    {
        public string Title { get; set; }
        public string Name { get; set; }

    }
}
