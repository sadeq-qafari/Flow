namespace Core.Meteor
{
    public interface IHaveTenant
    {
        public int? TenantId { get; set; }
    }

    public interface IHaveTenant0
    {
        public bool HasTenant0 { get; set; }
    }

    public interface IHaveCreatedBy
    {
        public int CreatedBy { get; set; }
    }

    public interface IHaveModifiedBy
    {
        public int? ModifiedBy { get; set; }
    }

    public interface IHaveActionBy
    {
        public int ActionBy { get; set; }
    }

    public interface IHaveBranch
    {
        public int? BranchId { get; set; }
    }

    public interface IAmDbSelect : IHaveTenant
    {
    }

    public interface IAmDbInsert : IHaveCreatedBy, IHaveTenant
    {
    }

    public interface IAmDbUpdate : IHaveModifiedBy, IHaveTenant, IHaveTenant0
    {
    }

    public interface IAmDbDelete : IAmDbUpdate
    {
    }

    public interface INeedLog
    {
    }

    public interface IHaveTableName
    {
        string TableName { get; set; }
    }
}
