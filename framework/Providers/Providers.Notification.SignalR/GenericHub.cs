using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Providers.Notification.SignalR
{
    public class GenericHub : Hub
    {
        public const string PublicGroup = "public";
        public const string CustomerGroup = "customer";
        public const string EmployeeGroup = "employee";

        private readonly HubClientManager _hubClientManager;



        public GenericHub(HubClientManager hubClientManager)
        {
            _hubClientManager = hubClientManager;
        }

        public Task Login(string token, string target)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
            var userId = int.Parse(jsonToken?.Claims.FirstOrDefault(x => x.Type == "sub")?.Value ?? "0");
            if (userId > 0)
            {
                var tenantId = int.Parse(jsonToken?.Claims.FirstOrDefault(x => x.Type == "tenant_id")?.Value ?? "0");
                switch (target)
                {
                    case "employee":
                        var roles = jsonToken?.Claims
                            .Where(x => x.Type == "role")
                            .Select(x => x.Value)
                            .ToList();
                        Groups.AddToGroupAsync(Context.ConnectionId,
                            roles?.Contains("employee") ?? false
                                ? EmployeeGroup
                                : CustomerGroup);
                        break;
                    default:
                        Groups.AddToGroupAsync(Context.ConnectionId, CustomerGroup);
                        break;
                }

                var roleIds = jsonToken?.Claims
                    .Where(x => x.Type == "role")
                    .Select(x => int.Parse(x.Value))
                    .ToList();

                _hubClientManager.AddUser(userId, tenantId, roleIds, Context.ConnectionId);
            }

            return Task.CompletedTask;
        }

        public override async Task OnConnectedAsync()
        {
            var originUrl = Context.GetHttpContext().Request.Headers["Origin"];
            var tenantId = await _hubClientManager.GetTenantIdByOriginUrl(originUrl);

            _hubClientManager.AddUser(0, tenantId, new List<int>(), Context.ConnectionId);

            await base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _hubClientManager.RemoveConnectionId(Context.ConnectionId);

            return base.OnDisconnectedAsync(exception);
        }
    }
}
