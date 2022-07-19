using Meteor.Operation.Db.Default;

namespace Core.Meteor.Dto
{
    public class DbSelectInDto : IAmDbSelect, IDbModel<int>
    {
        public int Id { get; set; }
        public int? TenantId { get; set; }
    }
}
