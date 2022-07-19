using Core.Meteor;

namespace Tenant.Operations.Setting.Queries
{
    public class GetSettingExcel : DbQueryExcel<Setting>
    {
        public GetSettingExcel() : base("[Tenant].[Setting]")
        {
        }
    }
}