using Core.Meteor;

namespace Tenant.Operations.Contact.Commands
{
    public class RemoveContact : DbDeleteAsync
    {
        public RemoveContact() : base("[Tenant].[Contact]")
        {
        }
    }
}