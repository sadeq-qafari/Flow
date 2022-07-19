using Core.Meteor;

namespace Tenant.Operations.Setting.Queries
{
    public class GetSetting : DbSelectAsync<Setting?>
    {
        public GetSetting() : base("[Tenant].[Setting]")
        {
        }
    }
}