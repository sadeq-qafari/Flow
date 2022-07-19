using Core.Meteor;
using Flow.Operations.Lookup.Dtos;

namespace Flow.Operations.Lookup.Commands
{
    public class LookupAdd : DbInsertAsync<LookupAddInDto>
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

