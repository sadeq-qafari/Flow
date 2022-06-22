using Saanaa.Core.Meteor;

namespace Tenant.Operations.Setting.Queries
{
    public class GetSettingAsDropDown : SaanaaDbQueryAsDropDown<Setting>
    {
        public GetSettingAsDropDown() : base("[Tenant].[Setting]")
        {
        }
    }
}
