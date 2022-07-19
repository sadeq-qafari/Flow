using Identity.Operations.Database.TenantUrl.Dtos;
using Core.Meteor;

namespace Identity.Operations.Database.TenantUrl.Commands
{
    public class TenantUrlAdd : DbInsertAsync<TenantUrlAddInDto>
    {
        public TenantUrlAdd() : base("[Identity].[TenantUrl]",
            @"[TypeLookup],
						[Url],
						[IsDefault]",
            @"@TypeLookup,
						@Url,
						@IsDefault")
        {
        }
    }
}

