using Core.Meteor.Dto;

namespace Tenant.Operations.PricingItem.Dtos
{
    public class PricingItemAddInDto : DbInsertInDto
    {
        public string Title { get; set; }
        public string Name { get; set; }

    }
}
