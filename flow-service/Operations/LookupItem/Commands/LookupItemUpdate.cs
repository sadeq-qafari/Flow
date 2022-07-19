using Core.Meteor;
using Flow.Operations.LookupItem.Dtos;

namespace Flow.Operations.LookupItem.Commands
{
    public class LookupItemUpdate : DbUpdateAsync<LookupItemUpdateInDto>
    {
        public LookupItemUpdate() : base("[Flow].[LookupItem]",
            @"[LookupId]=@LookupId,
					[Title]=@Title,
					[Value]=@Value,
					[Description]=@Description,
					[Index]=@Index,
					[Icon]=@Icon,
					[ColorHex]=@ColorHex")
        {
        }
    }
}