using Core.Meteor;

namespace Tenant.Operations.Staff.Queries
{
    public class GetStaffAsDropDown : DbQueryAsDropDown<Staff>
    {
        public GetStaffAsDropDown() : base("[Tenant].[v_Staff]")
        {
        }
    }
}
