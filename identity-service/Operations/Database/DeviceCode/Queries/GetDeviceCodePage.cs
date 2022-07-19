using Identity.Operations.Database.DeviceCode.Dtos;
using Core.Meteor;

namespace Identity.Operations.Database.DeviceCode.Queries
{
    public class GetDeviceCodePage : DbQueryPage<DeviceCodeDto>
    {
        public GetDeviceCodePage() : base("[Identity].[DeviceCode]")
        {
        }
        
    }
}