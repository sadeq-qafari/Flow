using Saanaa.Core.Meteor;

namespace Tenant.Operations.Setting.Queries
{
    public class GetSettingByIds : SaanaaDbQueryByIds<Setting>
    {
        public GetSettingByIds() : base("[Tenant].[Setting]")
        {
        }
    }
}