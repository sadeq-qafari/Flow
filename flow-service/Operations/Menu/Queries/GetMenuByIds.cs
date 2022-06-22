using Saanaa.Core.Meteor;

namespace Flow.Operations.Menu.Queries
{
    public class GetMenuByIds : SaanaaDbQueryByIds<Menu>
    {
        public GetMenuByIds() : base("[Flow].[Menu]")
        {
        }
    }
}
