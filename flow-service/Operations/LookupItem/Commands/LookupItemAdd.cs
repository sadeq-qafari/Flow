using Flow.Operations.LookupItem.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.LookupItem.Commands
{
    public class LookupItemAdd : SaanaaDbInsertAsync<LookupItemAddInDto>
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

