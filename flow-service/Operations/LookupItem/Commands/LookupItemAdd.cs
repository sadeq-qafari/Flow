using Core.Meteor;
using Flow.Operations.LookupItem.Dtos;

namespace Flow.Operations.LookupItem.Commands
{
    public class LookupItemAdd : DbInsertAsync<LookupItemAddInDto>
    {
        public LookupItemAdd() : base("[Flow].[LookupItem]",
            @"[LookupId],
						[Title],
						[Value],
						[Description],
						[Index],
						[Icon],
						[ColorHex]",
            @"@LookupId,
						@Title,
						@Value,
						@Description,
						@Index,
						@Icon,
						@ColorHex")
        {
        }
    }
}

