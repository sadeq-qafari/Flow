using Saanaa.Core.Meteor.Dto;

namespace Flow.Operations.FormPermission.Dtos
{
    public class FormPermissionUpdateInDto : SaanaaDbUpdateInDto
    {
        public int RoleId { get; set; }
        public int FormId { get; set; }
        public int PermissionTypeLookup { get; set; }
        public int? FormActionId { get; set; }

    }
}
