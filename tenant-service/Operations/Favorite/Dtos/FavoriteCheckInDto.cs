using Core.Meteor;

namespace Tenant.Operations.Favorite.Dtos
{
    public class FavoriteCheckInDto : IHaveActionBy, IHaveTenant
    {
        public string? ServiceName { get; set; }
        public string? ModelName { get; set; }
        public int EntityId { get; set; }
        public int ActionBy { get; set; }
        public int? TenantId { get; set; }
    }
}