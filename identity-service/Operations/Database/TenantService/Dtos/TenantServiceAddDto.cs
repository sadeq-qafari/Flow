using NodaTime;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantService.Dtos
{
    public class TenantServiceAddInDto : IHaveCreatedBy
    {
        public int ServiceId { get; set; }
        public Instant ExpireDate { get; set; }

        public int CreatedBy { get; set; }
        public int TenantId { get; set; }
        public bool IsActive { get; set; }
    }
}
