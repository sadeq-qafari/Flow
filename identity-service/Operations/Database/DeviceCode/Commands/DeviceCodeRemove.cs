using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.DeviceCode.Commands
{
    public class DeviceCodeRemove : SaanaaDbDeleteAsync
    {
        public DeviceCodeRemove() : base("[Identity].[DeviceCode]")
        {
        }
    }
}