using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.DeviceCode.Queries
{
    public class GetDeviceCodeExcel : SaanaaDbQueryExcel<DeviceCode>
    {
        public GetDeviceCodeExcel() : base("[Identity].[DeviceCode]")
        {
        }
    }
}