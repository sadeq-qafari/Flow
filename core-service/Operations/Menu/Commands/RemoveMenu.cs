using Core.Meteor;

namespace Core.Operations.Menu.Commands
{
    public class RemoveMenu : DbDeleteAsync
    {
        public RemoveMenu() : base("[Core].[Menu]")
        {
        }
    }
}
