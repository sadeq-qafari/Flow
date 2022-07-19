using Core.Meteor;
using Tenant.Operations.Report.Dtos;

namespace Tenant.Operations.Report.Commands
{
    public class ReportUpdate : DbUpdateAsync<ReportUpdateInDto>
    {
        public ReportUpdate() : base("[Tenant].[Report]",
            @"[Title]=@Title,
					[Name]=@Name,
					[TypeLookup]=@TypeLookup,
					[ServiceName]=@ServiceName,
					[PermissionName]=@PermissionName,
					[Link]=@Link,
					[Size]=@Size,
					[Query]=@Query,
					[Parameters]=@Parameters")
        {
        }
    }
}