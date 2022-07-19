using Core.Meteor;

namespace Flow.Operations.Menu.Commands
{
    public class RemoveMenu : DbDeleteAsync
    {
        public RemoveMenu() : base("[Flow].[Menu]")
        {
        }
    }
}
