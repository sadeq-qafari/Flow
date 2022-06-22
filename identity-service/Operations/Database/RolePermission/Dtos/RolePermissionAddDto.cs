using Saanaa.Core.Meteor.Dto;

namespace Identity.Operations.Database.RolePermission.Dtos
{
    public class RolePermissionAddInDto : SaanaaDbInsertInDto
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

    }
}
