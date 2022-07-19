using Core.Meteor;
using Flow.Operations.FormPermission.Dtos;

namespace Flow.Operations.FormPermission.Commands
{
    public class FormPermissionUpdate : DbUpdateAsync<FormPermissionUpdateInDto>
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