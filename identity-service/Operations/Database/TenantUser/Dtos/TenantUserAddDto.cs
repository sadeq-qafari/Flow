using Saanaa.Core.Meteor.Dto;

namespace Identity.Operations.Database.TenantUser.Dtos
{
    public class TenantUserAddInDto : SaanaaDbInsertInDto
    {
        public int? BranchId { get; set; }
        public int UserId { get; set; }
        public bool IsBanned { get; set; }
        public bool IsDefault { get; set; }

    }
}
