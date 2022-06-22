using Saanaa.Core.Meteor;

namespace Core.Operations.Application.Commands
{
    public class ApplicationRemove : SaanaaDbDeleteAsync
    {
        public ApplicationRemove() : base("[Core].[Application]")
        {
        }
    }
}