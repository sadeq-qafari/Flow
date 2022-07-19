using Core.Meteor.Dto;

namespace Identity.Operations.Database.RolePermission.Dtos
{
    public class RolePermissionAddInDto : DbInsertInDto
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

    }
}
