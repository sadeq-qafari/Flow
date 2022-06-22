using Identity.Operations.Database.DeviceCode.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.DeviceCode.Queries
{
    public class GetDeviceCodePage : SaanaaDbQueryPage<DeviceCodeDto>
    {
        public GetDeviceCodePage() : base("[Identity].[DeviceCode]")
        {
        }
        
    }
}