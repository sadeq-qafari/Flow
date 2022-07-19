using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Providers.Notification.SignalR
{
    public class HubClientManager
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public List<HubClientDto> Clients { get; set; }

        private readonly string _identityServiceUrl;
        private readonly ConcurrentDictionary<string, int> _tenantIdByOrigin;

        public HubClientManager(IHttpClientFactory httpClientFactory, IOptions<HubClientManagerOptions> options)
        {
            _httpClientFactory = httpClientFactory;
            _identityServiceUrl = options.Value.IdentityServiceUrl;
            _tenantIdByOrigin = new ConcurrentDictionary<string, int>();
            Clients = new List<HubClientDto>();
        }

        public HubClientDto GetUser(int userId, int tenantId) =>
            Clients.FirstOrDefault(x => x.UserId == userId && x.TenantId == tenantId);

        public List<string> GetUserConnectionIds(int userId) =>
            Clients.Where(x => x.UserId == userId)
                .SelectMany(x => x.ConnectionIds)
                .ToList();

        public async Task<int> GetTenantIdByOriginUrl(string url)
        {
            if (!_tenantIdByOrigin.TryGetValue(url, out var tenantId))
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("origin", new string[] {url});
                var res = await client.PostAsync($"{_identityServiceUrl}/api/tenant/GetTenantInfoWithUrl", null);
                var content = await res.Content.ReadAsStringAsync();
                if (JsonConvert.DeserializeObject(content) is JObject json)
                {
                    if (json.GetValue("isSuccess")?.Value<bool>() ?? false)
                    {
                        tenantId = json.GetValue("model")?.Value<JObject>().GetValue("id")?.Value<int>() ?? 0;
                        _tenantIdByOrigin.TryAdd(url, tenantId);
                    }
                }
            }

            return tenantId;
        }

        public void AddUser(in int userId, in int tenantId, List<int> roleIds, string connectionId)
        {
            var user = GetUser(userId, tenantId);
            if (user == null)
                Clients.Add(new HubClientDto
                {
                    UserId = userId,
                    TenantId = tenantId,
                    RoleIds = roleIds,
                    ConnectionIds = new List<string> {connectionId}
                });
            else
                user.ConnectionIds.Add(connectionId);
        }

        public void RemoveConnectionId(string connectionId)
        {
            // we may store connectionId in two clients at most
            if (RemoveConnectionIdFromClients(connectionId))
                RemoveConnectionIdFromClients(connectionId);
        }

        private bool RemoveConnectionIdFromClients(string connectionId)
        {
            var user = Clients.FirstOrDefault(x => x.ConnectionIds.Contains(connectionId));
            if (user == null)
                return false;

            user.ConnectionIds.Remove(connectionId);
            if (user.ConnectionIds.Count == 0)
                Clients.Remove(user);

            return true;
        }

        public IReadOnlyList<string> GetClientsByTenant(int tenantId) =>
            Clients.Where(x => x.TenantId == tenantId)
                .SelectMany(x => x.ConnectionIds).ToList();

        public IReadOnlyList<string> GetClientsByTenants(IEnumerable<int> tenantIds) =>
            Clients.Where(x => tenantIds.Contains(x.TenantId))
                .SelectMany(x => x.ConnectionIds).ToList();

        public IReadOnlyList<string> GetClientsByRoles(IEnumerable<int> roleIds) =>
            Clients.Where(x => x.RoleIds.Any(roleIds.Contains))
                .SelectMany(x => x.ConnectionIds).ToList();

        public IReadOnlyList<string> GetClientsByNotRoles(IEnumerable<int> roleIds) =>
            Clients.Where(x => !x.RoleIds.Any(roleIds.Contains))
                .SelectMany(x => x.ConnectionIds).ToList();

        public IReadOnlyList<string> GetClientsByTenantRole(int tenantId, int roleId) =>
            Clients.Where(x => x.TenantId == tenantId && x.RoleIds.Contains(roleId))
                .SelectMany(x => x.ConnectionIds)
                .ToList();

        public IReadOnlyList<string> GetClientsByTenantsRoles(IEnumerable<int> tenantIds, IEnumerable<int> roleIds) =>
            Clients.Where(x => tenantIds.Contains(x.TenantId) && x.RoleIds.Any(roleIds.Contains))
                .SelectMany(x => x.ConnectionIds)
                .ToList();

        public IReadOnlyList<string> GetClientsByTenantsNotRoles(IEnumerable<int> tenantIds, IEnumerable<int> roleIds) =>
            Clients.Where(x => tenantIds.Contains(x.TenantId) && !x.RoleIds.Any(roleIds.Contains))
                .SelectMany(x => x.ConnectionIds)
                .ToList();

        public IReadOnlyList<string> GetPublicClientsByTenants(IEnumerable<int> tenantIds) =>
            Clients.Where(x => tenantIds.Contains(x.TenantId) && x.UserId == 0)
                .SelectMany(x => x.ConnectionIds)
                .ToList();

        public IReadOnlyList<int> GetUserIdsByTenants(IEnumerable<int> tenantIds) =>
            Clients.Where(x => tenantIds.Contains(x.TenantId))
                .Select(x => x.UserId)
                .ToList();

        public int GetPublicUserCount(int tenantId) =>
            Clients.FirstOrDefault(x => x.TenantId == tenantId && x.UserId == 0)?.ConnectionIds.Count ?? 0;

        public int GetUserCount(int tenantId) =>
            Clients.Count(x => x.TenantId == tenantId && x.UserId != 0);

        public IEnumerable<HubClientDto> GetUsers(int tenantId) =>
            Clients.Where(x => x.TenantId == tenantId);
    }
}
