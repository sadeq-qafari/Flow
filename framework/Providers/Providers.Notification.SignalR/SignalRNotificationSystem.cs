using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Providers.Notification.SignalR
{
    public class SignalRNotificationSystem
    {
        private readonly IHubContext<GenericHub> _hub;
        private readonly HubClientManager _hubClientManager;

        public SignalRNotificationSystem(IHubContext<GenericHub> hub, HubClientManager hubClientManager)
        {
            _hub = hub;
            _hubClientManager = hubClientManager;
        }

        public Task SendToTenants(IEnumerable<int> tenantIds, string method, object arg) =>
            _hub.Clients.Clients(_hubClientManager.GetClientsByTenants(tenantIds)).SendAsync(method, arg);

        public Task SendToRoles(IEnumerable<int> roleIds, string method, object arg) =>
            _hub.Clients
                .Clients(_hubClientManager.GetClientsByRoles(roleIds))
                .SendAsync(method, arg);

        public Task SendToTenantsRoles(IEnumerable<int> tenantIds, IEnumerable<int> roleIds, string method, object arg) =>
            _hub.Clients
                .Clients(_hubClientManager.GetClientsByTenantsRoles(tenantIds, roleIds))
                .SendAsync(method, arg);

        public Task SendToPublicByTenants(IEnumerable<int> tenantIds, string method, object arg) =>
            _hub.Clients
                .Clients(_hubClientManager.GetPublicClientsByTenants(tenantIds))
                .SendAsync(method, arg);

        public Task SendToUser(int userId, string method, object arg) =>
            _hub.Clients
                .Clients(_hubClientManager.GetUserConnectionIds(userId))
                .SendAsync(method, arg);

        public int GetPublicUserCount(int tenantId) =>
            _hubClientManager.GetPublicUserCount(tenantId);

        public int GetUserCount(int tenantId) =>
            _hubClientManager.GetUserCount(tenantId);

        public IEnumerable<HubClientDto> GetUsers(int tenantId) =>
            _hubClientManager.GetUsers(tenantId);
    }
}