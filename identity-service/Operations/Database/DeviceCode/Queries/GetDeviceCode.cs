using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.DeviceCode.Queries
{
    public class GetDeviceCode : SaanaaDbSelectAsync<DeviceCode?>
    {
        public GetDeviceCode() : base("[Identity].[DeviceCode]")
        {
        }
    }
}