using System.Collections.Generic;
using Saanaa.Core.Meteor;

namespace Flow.Operations.Lookup.Dtos
{
    public class LookupUpsertInDto : IHaveTenant,IHaveActionBy
    {
        public int Id { get; set; }
        public int TypeLookup { get; set; }
        public string? Title { get; set; }
        public string? Query { get; set; }
        public string? Description { get; set; }
        public List<LookupUpsertItem> Items { get; set; }
        public int ActionBy { get; set; }
        public int? TenantId { get; set; }
    }

    public class LookupUpsertItem
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string? Value { get; set; }
        public string? Description { get; set; }
        public int Index { get; set; }
        public string? Icon { get; set; }
        public string? ColorHex { get; set; }
    }
}
