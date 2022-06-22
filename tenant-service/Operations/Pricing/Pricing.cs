using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Tenant.Operations.Pricing
{
    public class Pricing : BaseModelDto, IDropDown
    {
        public int ApplicationId { get; set; }
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public decimal FinalPrice { get; set; }
        public decimal GiftAmount { get; set; }
        public string Description { get; set; }
        public int? Duration { get; set; }
        public bool IsActive { get; set; }
    }
}
