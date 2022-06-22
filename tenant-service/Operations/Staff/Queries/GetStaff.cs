using Saanaa.Core.Meteor;

namespace Tenant.Operations.Staff.Queries
{
    public class GetStaff : SaanaaDbSelectAsync<Staff?>
    {
        public GetStaff() : base("[Tenant].[v_Staff]")
        {
        }
    }
}