using Saanaa.Core.Meteor;
using Tenant.Operations.Person.Dto;

namespace Tenant.Operations.Person.Queries
{
    public class GetPersonPage : SaanaaDbQueryPage<PersonDto>
    {
        public GetPersonPage() : base("[Tenant].[Person]")
        {
        }
        
    }
}