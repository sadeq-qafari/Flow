using Identity.Operations.Database.DeviceCode.Dtos;
using Core.Meteor;

namespace Identity.Operations.Database.DeviceCode.Commands
{
    public class DeviceCodeAdd : DbInsertAsync<DeviceCodeAddInDto>
    {
        public DeviceCodeAdd() : base("[Identity].[DeviceCode]",
            @"",
            @"")
        {
        }
    }
}

