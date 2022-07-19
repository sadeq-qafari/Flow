using Identity.Operations.Database.DeviceCode.Dtos;
using Core.Meteor;

namespace Identity.Operations.Database.DeviceCode.Commands
{
    public class DeviceCodeUpdate : DbUpdateAsync<DeviceCodeUpdateInDto>
    {
        public DeviceCodeUpdate() : base("[Identity].[DeviceCode]",
            @"")
        {
        }
    }
}