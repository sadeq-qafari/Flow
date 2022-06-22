using Saanaa.Core.Meteor;

namespace Tenant.Operations.Department.Commands
{
    public class RemoveDepartment : SaanaaDbDeleteAsync
    {
        public RemoveDepartment() : base("[Tenant].[Department]")
        {
        }
    }
}