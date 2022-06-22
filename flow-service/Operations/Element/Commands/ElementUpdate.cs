using Flow.Operations.Element.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.Element.Commands
{
    public class ElementUpdate : SaanaaDbUpdateAsync<ElementUpdateInDto>
    {
        public ElementUpdate() : base("[Flow].[Element]",
            @"[Name]=@Name,
					[Title]=@Title,
                    [Icon]=@Icon,
					[Config]=@Config,
					[AcceptableTypes]=@AcceptableTypes,
					[ComponentName]=@ComponentName")
        {
        }
    }
}