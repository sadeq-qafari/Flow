using Core.Meteor;
using Flow.Operations.Element.Dtos;

namespace Flow.Operations.Element.Commands
{
    public class ElementAdd : DbInsertAsync<ElementAddInDto>
    {
        public ElementAdd() : base("[Flow].[Element]",
            @"[Name],
						[Title],
						[Icon],
						[Config],
						[AcceptableTypes],
						[ComponentName]",
            @"@Name,
						@Title,
						@Icon,
						@Config,
						@AcceptableTypes,
						@ComponentName")
        {
        }
    }
}

