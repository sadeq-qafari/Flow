using System.Collections.Generic;
using Meteor.Operation.Db;

namespace Core.Meteor.Dto
{
    public record DbQueryReportInDto : DefaultQueryPageInput, IDataGridInDto, IAmDbSelect
    {
        public bool Paging { get; set; } = true;
        public string? Sort { get; set; }
        public string? Filter { get; set; }
        public int? TenantId { get; set; }
        public string ModelName { get; set; }
        public string ServiceName { get; set; }
        public Dictionary<string,object>? ReportParams { get; set; }
    }
}
