using Identity.Operations.Database.PersistedGrant.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.PersistedGrant.Commands
{
    public class PersistedGrantAdd : SaanaaDbInsertAsync<PersistedGrantAddInDto>
    {
        public PersistedGrantAdd() : base("[Identity].[PersistedGrant]",
            @"",
            @"")
        {
        }
    }
}

