using System;
using Core.Meteor.Dto;

namespace Tenant.Operations.PricingTenant.Dtos
{
    public class PricingTenantAddInDto : DbInsertInDto
    {
        public int PricingId { get; set; }
        public string? Title { get; set; }
        public decimal FinalPrice { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

    }
}
