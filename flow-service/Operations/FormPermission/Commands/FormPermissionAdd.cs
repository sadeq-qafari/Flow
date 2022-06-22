using Flow.Operations.FormPermission.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.FormPermission.Commands
{
    public class FormPermissionAdd : SaanaaDbInsertAsync<FormPermissionAddInDto>
    {
        public FormPermissionAdd() : base("[Flow].[FormPermission]",
            @"[RoleId],
						[FormId],
						[PermissionTypeLookup],
						[FormActionId]",
            @"@RoleId,
						@FormId,
						@PermissionTypeLookup,
						@FormActionId")
        {
        }
    }
}

