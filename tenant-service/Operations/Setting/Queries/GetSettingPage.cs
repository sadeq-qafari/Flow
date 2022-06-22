using Saanaa.Core.Meteor;
using Tenant.Operations.Setting.Dto;

namespace Tenant.Operations.Setting.Queries
{
    public class GetSettingPage : SaanaaDbQueryPage<SettingDto>
    {
        public GetSettingPage() : base("[Tenant].[Setting]")
        {
        }
        
    }
}