using Saanaa.Core.Meteor;

namespace Core.Operations.EntityRelation.Commands
{
    public class RemoveEntityRelation : SaanaaDbDeleteAsync
    {
        public RemoveEntityRelation() : base("[Core].[EntityRelation]")
        {
        }
    }
}
