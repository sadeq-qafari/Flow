using Flow.Operations.FormAction.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.FormAction.Commands
{
    public class FormActionUpdate : SaanaaDbUpdateAsync<FormActionUpdateInDto>
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