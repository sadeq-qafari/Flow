using Core.Meteor.Dto;

namespace Identity.Operations.Database.TenantUser.Dtos
{
    public class TenantUserUpdateInDto : DbUpdateInDto
    {
        public int? BranchId { get; set; }
        public int UserId { get; set; }
        public bool IsBanned { get; set; }
        public bool IsDefault { get; set; }

    }
}
