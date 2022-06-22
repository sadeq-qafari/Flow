using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Meteor.Operation;

namespace Identity.Helper
{
    public class ProfileService : IProfileService
    {
        private readonly OperationFactory _operationFactory;


        public ProfileService(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            context.IssuedClaims = context.Subject.Claims.ToList();
            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }
    }
}
