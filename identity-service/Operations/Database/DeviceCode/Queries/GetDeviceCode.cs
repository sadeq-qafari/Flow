using Core.Meteor;

namespace Identity.Operations.Database.DeviceCode.Queries
{
    public class GetDeviceCode : DbSelectAsync<DeviceCode?>
    {
        public GetDeviceCode() : base("[Identity].[DeviceCode]")
        {
        }
    }
}