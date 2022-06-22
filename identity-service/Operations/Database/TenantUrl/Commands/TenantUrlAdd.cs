using Identity.Operations.Database.TenantUrl.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantUrl.Commands
{
    public class TenantUrlAdd : SaanaaDbInsertAsync<TenantUrlAddInDto>
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

