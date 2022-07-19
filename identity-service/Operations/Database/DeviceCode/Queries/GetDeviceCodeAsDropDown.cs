using Core.Meteor;

namespace Identity.Operations.Database.DeviceCode.Queries
{
    public class GetDeviceCodeAsDropDown : DbQueryAsDropDown<DeviceCode>
    {
        public GetDeviceCodeAsDropDown() : base("[Identity].[DeviceCode]")
        {
        }
    }
}
