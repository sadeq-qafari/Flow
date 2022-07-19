using Core.Meteor;

namespace Identity.Operations.Database.DeviceCode.Commands
{
    public class DeviceCodeRemove : DbDeleteAsync
    {
        public DeviceCodeRemove() : base("[Identity].[DeviceCode]")
        {
        }
    }
}