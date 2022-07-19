using Core.Meteor;

namespace Tenant.Operations.Setting.Commands
{
    public class RemoveSetting : DbDeleteAsync
    {
        public RemoveSetting() : base("[Tenant].[Setting]")
        {
        }
    }
}