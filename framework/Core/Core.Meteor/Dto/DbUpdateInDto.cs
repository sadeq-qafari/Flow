using Meteor.Operation.Db.Default;

namespace Core.Meteor.Dto
{
    public class DbUpdateInDto : IAmDbUpdate, IDbModel<int>
    {
        public int Id { get; set; }
        public int? ModifiedBy { get; set; }
        public int? TenantId { get; set; }
        public bool HasTenant0 { get; set; }
        public bool IsActive { get; set; }
    }
}
