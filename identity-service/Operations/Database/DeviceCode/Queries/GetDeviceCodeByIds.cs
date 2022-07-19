using Core.Meteor;

namespace Identity.Operations.Database.DeviceCode.Queries
{
    public class GetDeviceCodeByIds : DbQueryByIds<DeviceCode>
    {
        public GetDeviceCodeByIds() : base("[Identity].[DeviceCode]")
        {
        }
    }
}