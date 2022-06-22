using Flow.Operations.Lookup.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.Lookup.Commands
{
    public class LookupAdd : SaanaaDbInsertAsync<LookupAddInDto>
    {
        public LookupAdd() : base("[Flow].[Lookup]",
            @"[Title],
						[TypeLookup],
						[Query],
						[WebServiceId],
						[Description]",
            @"@Title,
						@TypeLookup,
						@Query,
						@WebServiceId,
						@Description")
        {
        }
    }
}

