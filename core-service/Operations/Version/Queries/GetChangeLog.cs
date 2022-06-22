using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Operations.Version.Dto;
using Meteor.Operation.Db;

namespace Core.Operations.Version.Queries
{
    public class GetChangeLog : DbOperationAsync<GetChangeLogInDto, IEnumerable<Version>>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(sql => sql
                    .Select("[Core].[Version] Version", "Version.*")
                    .LeftJoin("[Identity].[TenantService]",
                        "TenantService.ServiceId = Version.ServiceId AND TenantService.TenantId = @TenantId")
                    .LeftJoin("[Tenant].[Organization]",
                        "Organization.ApplicationId = Version.ApplicationId AND Organization.Id = @TenantId")
                    .Where(wh => wh
                        .Where("[Tenant].[Organization].Id IS NOT NULL OR [Identity].[TenantService].Id IS NOT NULL")
                        .When(Input.AppType == AppType.Android, "IsAndroid = 1")
                        .When(Input.AppType == AppType.Ios, "IsIos = 1")
                        .When(Input.AppType == AppType.Pwa, "IsPwa = 1")
                        .When(Input.AppType == AppType.Web, "IsWeb = 1")
                        .When(Input.AppType == AppType.Panel, "IsPanel = 1")
                    )
                    .OrderBy("[Version].Title DESC"), new
                {
                    Input.TenantId
                }
            ).QueryAsync<Version>();
        }
    }
}
