using Core.Meteor;
using Flow.Operations.FormPermission.Dtos;

namespace Flow.Operations.FormPermission.Commands
{
    public class FormPermissionAdd : DbInsertAsync<FormPermissionAddInDto>
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

