using Core.Meteor;

namespace Core.Operations.Menu.Queries
{
    public class GetMenu : DbSelectAsync<Menu?>
    {
        public GetMenu() : base("[Core].[Menu]")
        {
        }
    }
}
