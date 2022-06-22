using Saanaa.Core.Meteor;

namespace Tenant.Operations.Staff.Commands
{
    public class StaffRemove : SaanaaDbDeleteAsync
    {
        public StaffRemove() : base("[Tenant].[v_Staff]")
        {
        }
    }
}