using Saanaa.Core.Meteor;

namespace Core.Operations.Application.Queries
{
    public class GetApplicationByIds : SaanaaDbQueryByIds<Application>
    {
        public GetApplicationByIds() : base("[Core].[Application]")
        {
        }
    }
}