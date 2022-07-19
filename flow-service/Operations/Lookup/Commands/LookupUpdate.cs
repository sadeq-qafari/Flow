using Core.Meteor;
using Flow.Operations.Lookup.Dtos;

namespace Flow.Operations.Lookup.Commands
{
    public class LookupUpdate : DbUpdateAsync<LookupUpdateInDto>
    {
        public LookupUpdate() : base("[Flow].[Lookup]",
            @"[Title]=@Title,
					[TypeLookup]=@TypeLookup,
					[Query]=@Query,
					[WebServiceId]=@WebServiceId,
					[Description]=@Description")
        {
        }
    }
}