using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Operations.Database.PersistedGrant.Commands;
using Identity.Operations.Database.PersistedGrant.Queries;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using Meteor.Operation;

namespace Identity.Helper
{
    public class PersistedGrantStore : IPersistedGrantStore
    {
        private readonly OperationFactory _operationFactory;

        public PersistedGrantStore(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        public Task StoreAsync(PersistedGrant grant) =>
            _operationFactory.New<UpsertPersistedGrant>().ExecuteAsync(grant);

        public Task<PersistedGrant?> GetAsync(string key) =>
            _operationFactory.New<GetPersistedGrantByKey>().ExecuteAsync(key);

        public Task<IEnumerable<PersistedGrant>?> GetAllAsync(PersistedGrantFilter filter) =>
            _operationFactory.New<GetAllPersistedGrants>().ExecuteAsync(filter);

        public Task RemoveAsync(string key) =>
            _operationFactory.New<PersistedGrantRemoveByKey>().ExecuteAsync(key);

        public Task RemoveAllAsync(PersistedGrantFilter filter) =>
            _operationFactory.New<PersistedGrantRemoveAll>().ExecuteAsync(filter);
    }
}
