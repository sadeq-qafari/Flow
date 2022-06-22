using Saanaa.Core.Meteor;

namespace Flow.Operations.Menu.Commands
{
    public class RemoveMenu : SaanaaDbDeleteAsync
    {
        public RemoveMenu() : base("[Flow].[Menu]")
        {
        }
    }
}
