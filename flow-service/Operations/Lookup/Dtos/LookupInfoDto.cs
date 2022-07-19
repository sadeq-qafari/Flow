using System.Collections.Generic;

namespace Flow.Operations.Lookup.Dtos
{
    public class LookupInfoDto
    {
        public int Id { get; set; }
        public int TypeLookup { get; set; }
        public string? Title { get; set; }
        public string? Query { get; set; }
        public string? Description { get; set; }
        public List<LookupInfoItemDto> Items { get; set; }
        public int ActionBy { get; set; }
        public int? TenantId { get; set; }
    }

    public class LookupInfoItemDto
    {
        public string Title { get; set; }
        public string? Value { get; set; }
        public string? Description { get; set; }
        public int Index { get; set; }
        public string? Icon { get; set; }
        public string? ColorHex { get; set; }
    }
}
