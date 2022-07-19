using Core.Meteor;
using Meteor.Operation.Db;

namespace Flow.Operations.Form.Dtos
{
    public record GetFormGridInDto : DefaultQueryPageInput, IHaveTenant
    {
        public string? FormName { get; set; }
        public string? Sort { get; set; }
        public string? Filter { get; set; }
        public bool Paging { get; set; } = true;
        public int? TenantId { get; set; }
    }
}
