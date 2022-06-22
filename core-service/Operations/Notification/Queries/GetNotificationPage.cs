using Core.Operations.Notification.Dto;
using Humanizer;
using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;

namespace Core.Operations.Notification.Queries
{
    public class GetNotificationPage : SaanaaDbQueryPage<NotificationDto>
    {
        public GetNotificationPage() : base("[Base].[Notification]")
        {
        }

        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            return SqlFactory!.Create()
                .Select("[Base].[Notification] Notification",
                    isForCount ? "COUNT(*)" : "Notification.*, Notification1.Title AS UserTitle")
                .LeftJoin("[Base].[Notification] Notification1",
                    "Notification.UserId=Notification1.Id AND Notification1.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName)
        {
            return fieldName.Pascalize() switch
            {
                "UserTitle" => "Notification1.Title",
                _ => $"[Notification].[{fieldName}]"
            };
        }
    }
}
