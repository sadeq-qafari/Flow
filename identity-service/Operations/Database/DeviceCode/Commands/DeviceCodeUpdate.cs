using Identity.Operations.Database.DeviceCode.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.DeviceCode.Commands
{
    public class DeviceCodeUpdate : SaanaaDbUpdateAsync<DeviceCodeUpdateInDto>
    {
        public DeviceCodeUpdate() : base("[Identity].[DeviceCode]",
            @"")
        {
        }
    }
}