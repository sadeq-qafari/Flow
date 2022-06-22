using System.Threading.Tasks;
using Identity.Operations.Database.Client.Queries;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using Meteor.Operation;

namespace Identity.Helper
{
    public class ClientStore : IClientStore
    {
        private readonly OperationFactory _operationFactory;

        public ClientStore(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        public Task<Client?> FindClientByIdAsync(string clientId) =>
            _operationFactory.New<GetClient>().ExecuteAsync(clientId);
    }
}
