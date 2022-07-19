using Core.Meteor.Dto;

namespace Identity.Operations.Database.RolePermission.Dtos
{
    public class RolePermissionUpdateInDto : DbUpdateInDto
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

    }
}
