using Flow.Operations.Lookup.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.Lookup.Commands
{
    public class LookupUpdate : SaanaaDbUpdateAsync<LookupUpdateInDto>
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