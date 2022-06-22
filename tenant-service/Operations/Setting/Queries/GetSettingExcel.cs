using Saanaa.Core.Meteor;

namespace Tenant.Operations.Setting.Queries
{
    public class GetSettingExcel : SaanaaDbQueryExcel<Setting>
    {
        public GetSettingExcel() : base("[Tenant].[Setting]")
        {
        }
    }
}