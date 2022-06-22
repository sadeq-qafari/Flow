using Core.Operations.Version.Dto;
using Humanizer;
using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;

namespace Core.Operations.Version.Queries
{
    public class GetVersionPage : SaanaaDbQueryPage<VersionDto>
    {
        public GetVersionPage() : base("[Core].[Version]")
        {
        }

        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            return SqlFactory!.Create().Select("[Core].[Version] Version",
                    isForCount
                        ? "COUNT(*)"
                        : "Version.*, Service.Title AS ServiceTitle, Application.Title AS ApplicationTitle")
                .LeftJoin("[Core].[Service] Service", "Version.ServiceId = Service.Id AND Service.IsDeleted=0")
                .LeftJoin("[Core].[Application] Application",
                    "Version.ApplicationId = Application.Id AND Application.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName)
        {
            return fieldName.Pascalize() switch
            {
                "ServiceTitle" => "Service.Title",
                "ApplicationTitle" => "Application.Title",
                _ => $"[Version].[{fieldName}]"
            };
        }
    }
}
