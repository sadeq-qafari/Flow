using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Operations.Database.ApiResource.Queries;
using Identity.Operations.Database.ApiScope.Queries;
using Identity.Operations.Database.IdentityResource.Queries;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using Meteor.Operation;

namespace Identity.Helper
{
    public class ResourceStore : IResourceStore
    {
        private readonly OperationFactory _operationFactory;

        public ResourceStore(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        public Task<IEnumerable<IdentityResource>?> FindIdentityResourcesByScopeNameAsync(IEnumerable<string> scopeNames) =>
            _operationFactory.New<GetIdentityResourcesByScopeName>().ExecuteAsync(scopeNames);

        public Task<IEnumerable<ApiScope>?> FindApiScopesByNameAsync(IEnumerable<string> scopeNames) =>
            _operationFactory.New<GetApiScopesByName>().ExecuteAsync(scopeNames);

        public Task<IEnumerable<ApiResource>?> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames) =>
            _operationFactory.New<GetApiResourcesByScopeName>().ExecuteAsync(scopeNames);

        public Task<IEnumerable<ApiResource>?> FindApiResourcesByNameAsync(IEnumerable<string> apiResourceNames) =>
            _operationFactory.New<GetApiResourcesByName>().ExecuteAsync(apiResourceNames);

        public async Task<Resources> GetAllResourcesAsync()
        {
            var identities = await _operationFactory.New<GetIdentityResourcesByScopeName>().ExecuteAsync(null);
            var apis = await _operationFactory.New<GetApiResourcesByName>().ExecuteAsync(null);
            var scopes = await _operationFactory.New<GetApiScopesByName>().ExecuteAsync(null);

            return new Resources(identities, apis, scopes);
        }
    }
}
