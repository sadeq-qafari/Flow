using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.DeviceCode.Queries
{
    public class GetDeviceCodeByIds : SaanaaDbQueryByIds<DeviceCode>
    {
        public GetDeviceCodeByIds() : base("[Identity].[DeviceCode]")
        {
        }
    }
}