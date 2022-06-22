using Saanaa.Core.Meteor.Dto;

namespace Identity.Operations.Database.UserRole.Dtos
{
    public class UserRoleAddInDto : SaanaaDbInsertInDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int? BranchId { get; set; }
        public bool IsDefault { get; set; }

    }
}
