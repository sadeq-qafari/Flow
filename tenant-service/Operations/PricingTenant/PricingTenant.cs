using System;
using Core.Meteor;
using Core.Meteor.Dto;

namespace Tenant.Operations.PricingTenant
{
    public class PricingTenant : BaseModelDto, IDropDown
    {
        public int PricingId { get; set; }
        public string? Title { get; set; }
        public decimal FinalPrice { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool IsActive { get; set; }

    }
}
