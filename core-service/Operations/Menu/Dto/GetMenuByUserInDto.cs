using Core.Meteor;

namespace Core.Operations.Menu.Dto
{
    public class GetMenuByUserInDto : IHaveTenant, IHaveActionBy
    {
        public int ActionBy { get; set; }
        public int? BranchId { get; set; }
        public int? TenantId { get; set; }
    }
}
