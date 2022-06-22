using Identity.Operations.Database.DeviceCode.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.DeviceCode.Commands
{
    public class DeviceCodeAdd : SaanaaDbInsertAsync<DeviceCodeAddInDto>
    {
        public DeviceCodeAdd() : base("[Identity].[DeviceCode]",
            @"",
            @"")
        {
        }
    }
}

