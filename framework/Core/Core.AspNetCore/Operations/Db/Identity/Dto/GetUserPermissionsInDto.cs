using Core.Meteor;

namespace Core.AspNetCore.Operations.Db.Identity.Dto
{
    public class GetUserPermissionsInDto : IHaveActionBy,IHaveTenant
    {
        public int ActionBy { get; set; }
        public int? TenantId { get; set; }
        public int? BranchId { get; set; }
    }
}
