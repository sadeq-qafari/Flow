using System.Collections.Generic;

namespace Flow.Core.Models
{
    public class LookupModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public LookupTypeEnum TypeLookup { get; set; }
        public string? Query { get; set; }
        public int? WebServiceId { get; set; }
        public string? Description { get; set; }
        public List<LookupItemModel> Options { get; set; }
    }
}
