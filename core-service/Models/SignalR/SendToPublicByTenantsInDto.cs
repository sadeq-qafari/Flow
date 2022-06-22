namespace Core.Models.SignalR
{
    public class SendToPublicByTenantsInDto : SendNotificationInDto
    {
        public int[] TenantIds { get; set; }

    }
}
