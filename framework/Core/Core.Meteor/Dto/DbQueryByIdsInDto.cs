namespace Core.Meteor.Dto
{
    public class DbQueryByIdsInDto : IAmDbSelect
    {
        public string? Ids { get; set; }
        public int? TenantId { get; set; }
    }
}
