using Flow.Operations.FormAction.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.FormAction.Commands
{
    public class FormActionAdd : SaanaaDbInsertAsync<FormActionAddInDto>
    {
        public FormActionAdd() : base("[Flow].[FormAction]",
            @"[Name],
						[Title],
						[ColorHex],
						[FormId],
						[TypeLookup],
						[Script]",
            @"@Name,
						@Title,
						@ColorHex,
						@FormId,
						@TypeLookup,
						@Script")
        {
        }
    }
}

