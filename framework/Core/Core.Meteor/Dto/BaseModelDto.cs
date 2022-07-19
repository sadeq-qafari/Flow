using NodaTime;

namespace Core.Meteor.Dto
{
    public class BaseModelDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public Instant CreatedAt { get; set; }
        public Instant? ModifiedAt { get; set; }
        public int? TenantId { get; set; }
    }
}
