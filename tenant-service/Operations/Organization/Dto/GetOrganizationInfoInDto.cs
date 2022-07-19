using Core.Meteor;

namespace Tenant.Operations.Organization.Dto
{
    public class GetOrganizationInfoInDto : IAmDbSelect
    {
        public int? TenantId { get; set; }
    }
}
