using Saanaa.Core.Meteor;

namespace Core.Operations.Version.Queries
{
    public class GetVersion : SaanaaDbSelectAsync<Version?>
    {
        public GetVersion() : base("[Core].[Version]")
        {
        }
    }
}
