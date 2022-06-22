using Saanaa.Core.Meteor;

namespace Tenant.Operations.Contact.Queries
{
    public class GetContactExcel : SaanaaDbQueryExcel<Contact>
    {
        public GetContactExcel() : base("[Tenant].[Contact]")
        {
        }
    }
}