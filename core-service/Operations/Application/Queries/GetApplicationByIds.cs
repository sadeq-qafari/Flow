using Core.Meteor;

namespace Core.Operations.Application.Queries
{
    public class GetApplicationByIds : DbQueryByIds<Application>
    {
        public GetApplicationByIds() : base("[Core].[Application]")
        {
        }
    }
}