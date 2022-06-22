using Saanaa.Core.Meteor;

namespace Core.Operations.Application.Queries
{
    public class GetApplicationAsDropDown : SaanaaDbQueryAsDropDown<Application>
    {
        public GetApplicationAsDropDown() : base("[Core].[Application]")
        {
        }
    }
}
