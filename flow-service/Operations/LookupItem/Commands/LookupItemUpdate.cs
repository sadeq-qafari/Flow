using Flow.Operations.LookupItem.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.LookupItem.Commands
{
    public class LookupItemUpdate : SaanaaDbUpdateAsync<LookupItemUpdateInDto>
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