using Core.Meteor;
using Flow.Operations.FormAction.Dtos;

namespace Flow.Operations.FormAction.Commands
{
    public class FormActionAdd : DbInsertAsync<FormActionAddInDto>
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

