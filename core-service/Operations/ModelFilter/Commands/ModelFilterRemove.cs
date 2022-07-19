using Core.Meteor;

namespace Core.Operations.ModelFilter.Commands
{
    public class ModelFilterRemove : DbDeleteAsync
    {
        public ModelFilterRemove() : base("[Core].[ModelFilter]")
        {
        }
    }
}