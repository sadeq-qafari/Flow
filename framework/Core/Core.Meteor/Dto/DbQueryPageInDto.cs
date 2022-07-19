using Meteor.Operation.Db;

namespace Core.Meteor.Dto
{
    public record DbQueryPageInDto : DefaultQueryPageInput, IDataGridInDto, IAmDbSelect, IHaveActionBy, IHaveTenant0, IHaveBranch
    {
        public bool Paging { get; set; } = true;
        public string? Sort { get; set; }
        public string? Filter { get; set; }
        public int? TenantId { get; set; }
        public int ActionBy { get; set; }
        public bool HasTenant0 { get; set; }
        public int? BranchId { get; set; }
    }
}
