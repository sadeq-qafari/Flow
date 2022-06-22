using Saanaa.Core.Meteor;

namespace Core.Operations.Menu.Commands
{
    public class RemoveMenu : SaanaaDbDeleteAsync
    {
        public RemoveMenu() : base("[Core].[Menu]")
        {
        }
    }
}
