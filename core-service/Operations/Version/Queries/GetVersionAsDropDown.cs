using Core.Meteor;

namespace Core.Operations.Version.Queries
{
    public class GetVersionAsDropDown : DbQueryAsDropDown<Version>
    {
        public GetVersionAsDropDown() : base("[Core].[Version]")
        {
        }
    }
}
