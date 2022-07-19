using System.Collections.Generic;
using Saanaa.Core.AspNetCore.Operations.Db.Payment.Dto;

namespace Saanaa.Tenant.Operations.PricingTenant.Dtos
{
    public class PricingTenantSettleInDto :
    {
        public int? ActionBy { get; set; }
        public int? TenantId { get; set; }
    }
}
