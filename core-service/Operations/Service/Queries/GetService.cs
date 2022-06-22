using Saanaa.Core.Meteor;

namespace Core.Operations.Service.Queries
{
    public class GetService : SaanaaDbSelectAsync<Service?>
    {
        public GetService() : base("[Core].[Service]")
        {
        }
    }
}
