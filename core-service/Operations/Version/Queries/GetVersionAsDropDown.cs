using Saanaa.Core.Meteor;

namespace Core.Operations.Version.Queries
{
    public class GetVersionAsDropDown : SaanaaDbQueryAsDropDown<Version>
    {
        public GetVersionAsDropDown() : base("[Core].[Version]")
        {
        }
    }
}
