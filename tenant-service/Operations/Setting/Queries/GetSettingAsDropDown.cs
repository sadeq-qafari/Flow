using Core.Meteor;

namespace Tenant.Operations.Setting.Queries
{
    public class GetSettingAsDropDown : DbQueryAsDropDown<Setting>
    {
        public GetSettingAsDropDown() : base("[Tenant].[Setting]")
        {
        }
    }
}
