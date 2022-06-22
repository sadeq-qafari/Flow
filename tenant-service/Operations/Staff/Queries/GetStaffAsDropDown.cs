using Saanaa.Core.Meteor;

namespace Tenant.Operations.Staff.Queries
{
    public class GetStaffAsDropDown : SaanaaDbQueryAsDropDown<Staff>
    {
        public GetStaffAsDropDown() : base("[Tenant].[v_Staff]")
        {
        }
    }
}
