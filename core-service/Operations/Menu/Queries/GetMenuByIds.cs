using Saanaa.Core.Meteor;

namespace Core.Operations.Menu.Queries
{
    public class GetMenuByIds : SaanaaDbQueryByIds<Menu>
    {
        public GetMenuByIds() : base("[Core].[Menu]")
        {
        }
    }
}
