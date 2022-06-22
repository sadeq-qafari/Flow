using Saanaa.Core.Meteor;

namespace Tenant.Operations.Setting.Commands
{
    public class RemoveSetting : SaanaaDbDeleteAsync
    {
        public RemoveSetting() : base("[Tenant].[Setting]")
        {
        }
    }
}