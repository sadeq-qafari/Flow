using Core.Meteor;
using Tenant.Operations.OrganizationDetail.Dtos;

namespace Tenant.Operations.OrganizationDetail.Commands
{
    public class OrganizationDetailUpdate : DbUpdateAsync<OrganizationDetailUpdateInDto>
    {
        public OrganizationDetailUpdate() : base("[Tenant].[OrganizationDetail]",
            @"[Key]=@Key,
					[Value]=@Value,
					[Type]=@Type")
        {
        }
    }
}