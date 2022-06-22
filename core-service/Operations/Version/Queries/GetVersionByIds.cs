using Saanaa.Core.Meteor;

namespace Core.Operations.Version.Queries
{
    public class GetVersionByIds : SaanaaDbQueryByIds<Version>
    {
        public GetVersionByIds() : base("[Core].[Version]")
        {
        }
    }
}
