using NodaTime;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantService.Dtos
{
    public class TenantServiceUpdateInDto : IHaveModifiedBy
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public Instant ExpireDate { get; set; }

        public int? TenantId { get; set; }
        public int? ModifiedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
