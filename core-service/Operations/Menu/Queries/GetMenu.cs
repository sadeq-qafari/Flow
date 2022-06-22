using Saanaa.Core.Meteor;

namespace Core.Operations.Menu.Queries
{
    public class GetMenu : SaanaaDbSelectAsync<Menu?>
    {
        public GetMenu() : base("[Core].[Menu]")
        {
        }
    }
}
