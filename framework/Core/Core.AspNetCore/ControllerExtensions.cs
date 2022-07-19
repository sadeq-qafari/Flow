using System.Linq;
using System.Threading.Tasks;
using Core.AspNetCore.Operations.Db.Log;
using Core.AspNetCore.Operations.Db.Log.Commands;
using Core.Meteor;
using Meteor;
using Meteor.Operation;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using NodaTime;

namespace Core.AspNetCore
{
    public static class ControllerExtensions
    {
        private static readonly UAParser.Parser UaParser = UAParser.Parser.GetDefault();

        public static Task LogUserAgent(this ControllerBase controller, OperationFactory operationFactory, int? entityId = null)
        {
            var uaString = controller.HttpContext.Request.Headers["User-Agent"].ToString();
            if (string.IsNullOrWhiteSpace(uaString))
                return Task.CompletedTask;

            var ua = UaParser.Parse(uaString);
            var tenantId = (int?)(controller.HttpContext.Items["TenantId"] ?? SqTenants.GetTenant(controller.HttpContext)?.Id);
            return operationFactory.New<LogUserAgent>().ExecuteAsync(new UserAgent
            {
                Host = controller.HttpContext.Request.Headers["SQ-Origin"].FirstOrDefault() ?? controller.HttpContext.Request.Headers["Origin"].ToString(),
                RemoteIpAddress = controller.HttpContext.Request.Headers["sq-ip-address"].FirstOrDefault() ?? (controller.HttpContext.Request?.Headers["x-forwarded-for"])?.ToString().Split(',').FirstOrDefault()  ?? controller.HttpContext.Connection.RemoteIpAddress?.ToString(),
                EndPoint = controller.Request.GetDisplayUrl(),
                ServiceName = EnvVars.Get("SERVICE_NAME"),
                ModelName = controller.RouteData.Values["controller"]?.ToString(),
                EntityId = entityId,
                ActionName = controller.RouteData.Values["action"]?.ToString(),
                UserDevice = ua.Device.Family,
                UserOs = ua.OS.Family,
                UserBrowser = ua.UA.Family,
                UserBrowserVersion = $"{ua.UA.Major}.{ua.UA.Minor}",
                CreatedBy = (int) (controller.HttpContext.Items["UserId"] ?? 0),
                CreatedAt = SystemClock.Instance.GetCurrentInstant(),
                TenantId = tenantId
            });
        }
    }
}
