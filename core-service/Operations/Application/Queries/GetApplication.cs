using Saanaa.Core.Meteor;

namespace Core.Operations.Application.Queries
{
    public class GetApplication : SaanaaDbSelectAsync<Application?>
    {
        public GetApplication() : base("[Core].[Application]")
        {
        }
    }
}