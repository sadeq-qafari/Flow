using Core.Meteor;
using Flow.Operations.Element.Dtos;

namespace Flow.Operations.Element.Commands
{
    public class ElementUpdate : DbUpdateAsync<ElementUpdateInDto>
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