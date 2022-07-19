using Core.Meteor;

namespace Tenant.Operations.Staff.Queries
{
    public class GetStaff : DbSelectAsync<Staff?>
    {
        public GetStaff() : base("[Tenant].[v_Staff]")
        {
        }
    }
}