using Core.Meteor;

namespace Tenant.Operations.Staff.Queries
{
    public class GetStaffByIds : DbQueryByIds<Staff>
    {
        public GetStaffByIds() : base("[Tenant].[v_Staff]")
        {
        }
    }
}