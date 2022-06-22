using Saanaa.Core.Meteor;

namespace Core.Operations.Service.Dto
{
    public class GetServicesInDto : IHaveTenant
    {
        public long? Version { get; set; }
        public int? TenantId { get; set; }
    }
}
