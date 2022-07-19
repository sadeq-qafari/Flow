using System;
using Microsoft.Extensions.DependencyInjection;

namespace Providers.Notification.SignalR
{
    public static class NotificationExtensions
    {
        public static IServiceCollection AddGenericHub(this IServiceCollection serviceCollection,
            Action<HubClientManagerOptions> options)
        {
            serviceCollection.Configure(options);
            serviceCollection.AddSingleton<HubClientManager>();
            serviceCollection.AddSignalR();
            serviceCollection.AddSingleton<SignalRNotificationSystem>();

            return serviceCollection;
        }
    }
}