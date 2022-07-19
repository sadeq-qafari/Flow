using Core.Meteor.Dto;

namespace Identity.Operations.Database.UserPermission.Dtos
{
    public class UserPermissionUpdateInDto : DbUpdateInDto
    {
        public int UserId { get; set; }
        public int PermissionId { get; set; }
        public int? BranchId { get; set; }
        public bool IsGranted { get; set; }

    }
}
