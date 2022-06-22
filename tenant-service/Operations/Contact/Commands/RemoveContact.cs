using Saanaa.Core.Meteor;

namespace Tenant.Operations.Contact.Commands
{
    public class RemoveContact : SaanaaDbDeleteAsync
    {
        public RemoveContact() : base("[Tenant].[Contact]")
        {
        }
    }
}