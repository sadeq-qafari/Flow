using Identity.Operations.Database.RolePermission.Dtos;
using Saanaa.Core.Meteor.Dto;

namespace Identity.Operations.Database.Role.Dtos
{
    public class RoleAddInDto : SaanaaDbInsertInDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ServiceId { get; set; }
        public PermissionCheckList? PermissionCheckList { get; set; }
    }
}
