using Core.Meteor;

namespace Core.Operations.Application.Queries
{
    public class GetApplicationAsDropDown : DbQueryAsDropDown<Application>
    {
        public GetApplicationAsDropDown() : base("[Core].[Application]")
        {
        }
    }
}
