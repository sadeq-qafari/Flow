using Saanaa.Core.Meteor;

namespace Tenant.Operations.Setting.Queries
{
    public class GetSetting : SaanaaDbSelectAsync<Setting?>
    {
        public GetSetting() : base("[Tenant].[Setting]")
        {
        }
    }
}