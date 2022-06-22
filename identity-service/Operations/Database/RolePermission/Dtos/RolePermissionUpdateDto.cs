using Saanaa.Core.Meteor.Dto;

namespace Identity.Operations.Database.RolePermission.Dtos
{
    public class RolePermissionUpdateInDto : SaanaaDbUpdateInDto
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

    }
}
