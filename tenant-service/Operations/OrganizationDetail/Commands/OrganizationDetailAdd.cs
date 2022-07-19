using Core.Meteor;
using Tenant.Operations.OrganizationDetail.Dtos;

namespace Tenant.Operations.OrganizationDetail.Commands
{
    public class OrganizationDetailAdd : DbInsertAsync<OrganizationDetailAddInDto>
    {
        public OrganizationDetailAdd() : base("[Tenant].[OrganizationDetail]",
            @"[Key],
						[Value],
						[Type]",
            @"@Key,
						@Value,
						@Type")
        {
        }
    }
}

