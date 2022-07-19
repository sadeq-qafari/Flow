using Identity.Operations.Database.PersistedGrant.Dtos;
using Core.Meteor;

namespace Identity.Operations.Database.PersistedGrant.Commands
{
    public class PersistedGrantAdd : DbInsertAsync<PersistedGrantAddInDto>
    {
        public PersistedGrantAdd() : base("[Identity].[PersistedGrant]",
            @"",
            @"")
        {
        }
    }
}

