using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.DeviceCode.Queries
{
    public class GetDeviceCodeAsDropDown : SaanaaDbQueryAsDropDown<DeviceCode>
    {
        public GetDeviceCodeAsDropDown() : base("[Identity].[DeviceCode]")
        {
        }
    }
}
