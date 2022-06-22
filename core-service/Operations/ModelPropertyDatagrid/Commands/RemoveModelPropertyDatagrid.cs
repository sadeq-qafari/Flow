using Saanaa.Core.Meteor;

namespace Core.Operations.ModelPropertyDatagrid.Commands
{
    public class RemoveModelPropertyDatagrid : SaanaaDbDeleteAsync
    {
        public RemoveModelPropertyDatagrid() : base("[Core].[ModelPropertyDatagrid]")
        {
        }
    }
}
