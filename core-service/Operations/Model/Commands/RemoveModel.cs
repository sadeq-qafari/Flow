using Core.Meteor;

namespace Core.Operations.Model.Commands
{
    public class RemoveModel : DbDeleteAsync
    {
        public RemoveModel() : base("[Core].[Model]")
        {
        }
    }
}
