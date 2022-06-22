using Meteor.Operation.Db.Default;

namespace Identity.Operations.Database.TenantRegisterRequest.Dtos
{
    public class TenantRegisterRequestChangeStatusInDto : IDbModel<int>
    {
        public int Id { get; set; }
        public string TenantName { get; set; }
    }
}
