using Meteor.Operation.Db.Default;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantUrl.Dtos
{
    public class TenantUrlUpdateInDto : IHaveModifiedBy, IDbModel<int>
    {
        public int Id { get; set; }
        public int TypeLookup { get; set; }
        public string Url { get; set; }
        public bool IsDefault { get; set; }
        public int? ModifiedBy { get; set; }
        public int? TenantId { get; set; }
        public bool HasTenant0 { get; set; }
        public bool IsActive { get; set; }
    }
}
