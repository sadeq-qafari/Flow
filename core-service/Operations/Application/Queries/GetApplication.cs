using Core.Meteor;

namespace Core.Operations.Application.Queries
{
    public class GetApplication : DbSelectAsync<Application?>
    {
        public GetApplication() : base("[Core].[Application]")
        {
        }
    }
}