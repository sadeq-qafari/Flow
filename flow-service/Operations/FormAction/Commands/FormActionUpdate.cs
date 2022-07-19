using Core.Meteor;
using Flow.Operations.FormAction.Dtos;

namespace Flow.Operations.FormAction.Commands
{
    public class FormActionUpdate : DbUpdateAsync<FormActionUpdateInDto>
    {
        public FormActionUpdate() : base("[Flow].[FormAction]",
            @"[Name]=@Name,
					[Title]=@Title,
					[ColorHex]=@ColorHex,
					[FormId]=@FormId,
					[TypeLookup]=@TypeLookup,
					[Script]=@Script")
        {
        }
    }
}