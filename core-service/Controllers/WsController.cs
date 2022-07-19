using System.Collections.Generic;
using System.Threading.Tasks;
using Core.AspNetCore.Security;
using Core.Meteor.Dto;
using Core.Models.SignalR;
using Core.Operations.Notification.Queries;
using Core.Operations.NotificationUser.Commands;
using Core.Operations.NotificationUser.Dto;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [ApiController]
    [OperationResult]
    [Route("[controller]")]
    public class WsController : ControllerBase
    {
        private readonly SignalRNotificationSystem _signalR;
        private readonly HubClientManager _hubClientManager;
        private readonly OperationFactory _operationFactory;

        public WsController(OperationFactory operationFactory, SignalRNotificationSystem signalR,
            HubClientManager hubClientManager)
        {
            _operationFactory = operationFactory;
            _signalR = signalR;
            _hubClientManager = hubClientManager;
        }

        [Authorize]
        [HttpGet]
        public dynamic GetTenantStatistics([FromQuery] int tenantId)
        {
            return new
            {
                PublicUserCount = _hubClientManager.GetPublicUserCount(tenantId),
                UserCount = _hubClientManager.GetUserCount(tenantId),
                Users = _hubClientManager.GetUsers(tenantId)
            };
        }

        [Authorize]
        [HttpPost("SendToPublicByTenants")]
        public async Task SendToPublicByTenants(SendToPublicByTenantsInDto model)
        {
            var userTenantId = HttpContext.UserInfo()!.TenantId;
            var createdBy = HttpContext.UserInfo()!.Id;
            var notification = await _operationFactory.New<GetNotification>().ExecuteAsync(
                new DbSelectInDto
                {
                    Id = model.NotificationId,
                    TenantId = userTenantId
                });
            if (model.Persist)
            {
                var userIds = _hubClientManager.GetUserIdsByTenants(model.TenantIds);
                var userNotifications = new List<AddNotificationUserInDto>();
                foreach (var userId in userIds)
                {
                    userNotifications.Add(new AddNotificationUserInDto
                    {
                        IsActive = false,
                        CreatedBy = 0,
                        TenantId = null,
                        UserId = 0,
                        NotificationId = 0,
                        Title = null,
                        Description = null,
                        Arg = null,
                        IsSeen = false,
                        SeenAt = default
                    });
                }

                await _operationFactory.New<AddNotificationUsers>().ExecuteAsync(userNotifications);
            }

            await _signalR.SendToPublicByTenants(model.TenantIds, notification.Method, notification.Arg);
        }

        // [Authorize]
        // [HttpPost("SendToUser")]
        // public async Task SendToUser(SendToUserInDto model)
        // {
        //     var userTenantId = HttpContext.UserInfo().TenantId; // User.GetTenantId();
        //     var userId = HttpContext.UserInfo().Id; // User.GetUserId();
        //     var notification = await _lazyDbConnection.ExecuteDbMessageAsync(new GetNotification
        //     {
        //         Id = model.NotificationId,
        //         TenantId = userTenantId
        //     });
        //     if (model.Persist)
        //     {
        //         var userIds = new int[]{model.UserId};
        //
        //         await _lazyDbConnection.ExecuteDbMessageAsync(new AddNotificationUsers
        //         {
        //             UserIds = userIds,
        //             CreatedBy = userId,
        //             TenantId = userTenantId
        //         });
        //     }
        //
        //     return _signalR.SendToUser(model.UserId, model.Method, model.Arg);
        // }

        public virtual string ReplaceParameters(string text, Dictionary<string, object> parameters)
        {
            foreach (var (key, value) in parameters)
                text = text.Replace($"${key}", value.ToString());

            return text;
        }
    }
}
