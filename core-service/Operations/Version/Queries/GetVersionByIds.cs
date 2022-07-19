using Core.Meteor;

namespace Core.Operations.Version.Queries
{
    public class GetVersionByIds : DbQueryByIds<Version>
    {
        public GetVersionByIds() : base("[Core].[Version]")
        {
        }
    }
}
