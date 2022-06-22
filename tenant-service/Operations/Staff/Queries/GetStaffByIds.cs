using Saanaa.Core.Meteor;

namespace Tenant.Operations.Staff.Queries
{
    public class GetStaffByIds : SaanaaDbQueryByIds<Staff>
    {
        public GetStaffByIds() : base("[Tenant].[v_Staff]")
        {
        }
    }
}