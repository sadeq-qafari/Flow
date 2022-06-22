using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantUrl.Dtos
{
    public class TenantUrlAddInDto : IHaveCreatedBy
    {
        public int TypeLookup { get; set; }
        public string Url { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int TenantId { get; set; }
    }
}
