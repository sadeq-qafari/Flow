using Core.Meteor;

namespace Core.Operations.Version.Queries
{
    public class GetVersion : DbSelectAsync<Version?>
    {
        public GetVersion() : base("[Core].[Version]")
        {
        }
    }
}
