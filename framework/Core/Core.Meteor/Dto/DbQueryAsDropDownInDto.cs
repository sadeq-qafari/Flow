namespace Core.Meteor.Dto
{
    public class DbQueryAsDropDownInDto : IAmDbSelect
    {
        public string? Ids { get; set; }
        public string? SearchValue { get; set; }
        public string? Filters { get; set; }
        public int? TenantId { get; set; }
    }
}
