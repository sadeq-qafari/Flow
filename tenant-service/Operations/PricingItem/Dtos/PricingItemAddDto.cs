using Saanaa.Core.Meteor.Dto;

namespace Tenant.Operations.PricingItem.Dtos
{
    public class PricingItemAddInDto : SaanaaDbInsertInDto
    {
        public string Title { get; set; }
        public string Name { get; set; }

    }
}
