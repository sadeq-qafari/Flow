using Core.Meteor;

namespace Core.Operations.ModelPropertyDatagrid.Commands
{
    public class RemoveModelPropertyDatagrid : DbDeleteAsync
    {
        public RemoveModelPropertyDatagrid() : base("[Core].[ModelPropertyDatagrid]")
        {
        }
    }
}
