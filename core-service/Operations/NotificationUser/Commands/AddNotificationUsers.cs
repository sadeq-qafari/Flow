using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Operations.NotificationUser.Dto;
using Meteor.Operation.Db;
using Meteor.Utils;

namespace Core.Operations.NotificationUser.Commands
{
    public class AddNotificationUsers : DbOperationAsync<List<AddNotificationUserInDto>, long>
    {
        protected override async Task ExecutionAsync()
        {
            const string? insertSql = @"
INSERT INTO Base.NotificationUser 
(
  UserId
 ,NotificationId
 ,Title
 ,Description
 ,Arg
 ,IsSeen
 ,SeenAt
 ,IsDeleted
 ,CreatedBy
 ,CreatedAt
 ,ModifiedBy
 ,ModifiedAt
 ,TenantId
)
VALUES";
            var valuesSql = string.Join(',', Input.Select(item =>
                $@"(
 {item.UserId},
 {item.NotificationId},
 N'{item.Title}',
 N'{item.Description}',
 N'{item.Arg.ToJson()}',
 0,
 NULL,
 0,
 {item.CreatedBy},
 GETDATE(),
 NULL,
 NULL,
 {item.TenantId}
)"));
            Output = await NewSql($"{insertSql}{valuesSql};").ExecuteAsync();
        }
    }
}
