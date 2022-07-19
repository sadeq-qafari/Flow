namespace Tenant.Operations.Favorite.Dtos
{
    public class FavoriteDto : Favorite
    {
        public string? ModelTitle { get; set; }
        public string? PersonTitle { get; set; }
        public string? EntityTitle { get; set; }
    }
}
