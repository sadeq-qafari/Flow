using Core.Meteor;

namespace Identity.Operations.Database.DeviceCode.Queries
{
    public class GetDeviceCodeExcel : DbQueryExcel<DeviceCode>
    {
        public GetDeviceCodeExcel() : base("[Identity].[DeviceCode]")
        {
        }
    }
}