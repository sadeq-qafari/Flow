using Core.Meteor;

namespace Tenant.Operations.Staff.Commands
{
    public class StaffRemove : DbDeleteAsync
    {
        public StaffRemove() : base("[Tenant].[v_Staff]")
        {
        }
    }
}