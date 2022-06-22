using Flow.Operations.FormPermission.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.FormPermission.Commands
{
    public class FormPermissionUpdate : SaanaaDbUpdateAsync<FormPermissionUpdateInDto>
    {
        public FormPermissionUpdate() : base("[Flow].[FormPermission]",
            @"[RoleId]=@RoleId,
					[FormId]=@FormId,
					[PermissionTypeLookup]=@PermissionTypeLookup,
					[FormActionId]=@FormActionId")
        {
        }
    }
}