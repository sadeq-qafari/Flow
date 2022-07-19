﻿using System.Collections.Generic;

 namespace Providers.Notification.SignalR
{
    public class HubClientDto
    {
        public int UserId { get; set; }
        public int TenantId { get; set; }
        public List<int> RoleIds { get; set; }
        public List<string> ConnectionIds { get; set; }
    }
}