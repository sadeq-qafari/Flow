using Core.Meteor;

namespace Core.Operations.Application.Commands
{
    public class ApplicationRemove : DbDeleteAsync
    {
        public ApplicationRemove() : base("[Core].[Application]")
        {
        }
    }
}