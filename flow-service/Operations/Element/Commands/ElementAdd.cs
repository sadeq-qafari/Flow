using Flow.Operations.Element.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.Element.Commands
{
    public class ElementAdd : SaanaaDbInsertAsync<ElementAddInDto>
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

