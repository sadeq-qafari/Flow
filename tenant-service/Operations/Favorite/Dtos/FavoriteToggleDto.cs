using Meteor.Operation.Db.Default;
using Saanaa.Core.Meteor;

namespace Tenant.Operations.Favorite.Dtos
{
    public class FavoriteToggleInDto : IHaveActionBy, IHaveTenant,IDbModel<int?>
    {
        public string? ServiceName { get; set; }
        public string? ModelName { get; set; }
        public int EntityId { get; set; }
        public int ActionBy { get; set; }
        public int? TenantId { get; set; }
        public int? Id => EntityId;
    }
}
