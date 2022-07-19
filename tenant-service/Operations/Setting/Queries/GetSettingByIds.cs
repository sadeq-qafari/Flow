using Core.Meteor;

namespace Tenant.Operations.Setting.Queries
{
    public class GetSettingByIds : DbQueryByIds<Setting>
    {
        public GetSettingByIds() : base("[Tenant].[Setting]")
        {
        }
    }
}