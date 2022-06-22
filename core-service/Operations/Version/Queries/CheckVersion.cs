using System.Threading.Tasks;
using Core.Operations.Version.Dto;
using Meteor.Operation.Db;

namespace Core.Operations.Version.Queries
{
    public class CheckVersion : DbOperationAsync<CheckVersionInDto, bool>
    {
        protected override async Task ExecutionAsync()
        {
            var latestVersion = await NewSql(sql => sql
                .Select("[Core].[Version]", "TOP 1 TRIM(Version.Title)")
                .LeftJoin("[Identity].[Tenant]",
                    "Tenant.ApplicationId = Version.ApplicationId AND Tenant.Id = @TenantId")
                .Where(wh => wh
                    .Where("[Identity].[Tenant].Id IS NOT NULL")
                    .When(Input.AppType == AppType.Android, "IsAndroid = 1")
                    .When(Input.AppType == AppType.Ios, "IsIos = 1")
                    .When(Input.AppType == AppType.Pwa, "IsPwa = 1")
                    .When(Input.AppType == AppType.Web, "IsWeb = 1")
                    .When(Input.AppType == AppType.Panel, "IsPanel = 1")
                )
                .OrderBy("CAST('/' + REPLACE([Version].Title, '.', '/') + '/' AS HIERARCHYID) DESC ")
            ).ExecuteScalarAsync<string>();
            var theVersion = new System.Version(Input.Version.Trim());
            var theLatestVersion = new System.Version(latestVersion);
            Output = theVersion.CompareTo(theLatestVersion) < 0;
        }
    }
}
