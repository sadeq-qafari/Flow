using Saanaa.Core.Meteor;
using Tenant.Operations.Report.Dtos;

namespace Tenant.Operations.Report.Commands
{
    public class ReportAdd : SaanaaDbInsertAsync<ReportAddInDto>
    {
        public ReportAdd() : base("[Tenant].[Report]",
            @"[Title],
						[Name],
						[TypeLookup],
						[ServiceName],
						[PermissionName],
						[Link],
						[Size],
						[Query],
						[Parameters]",
            @"@Title,
						@Name,
						@TypeLookup,
						@ServiceName,
						@PermissionName,
						@Link,
						@Size,
						@Query,
						@Parameters")
        {
        }
    }
}

