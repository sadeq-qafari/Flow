using Core.Meteor;
using Tenant.Operations.Dashboard.Dtos;

namespace Tenant.Operations.Dashboard.Commands
{
    public class DashboardUpdate : DbUpdateAsync<DashboardUpdateInDto>
    {
        public DashboardUpdate() : base("[Tenant].[Dashboard]",
            @"[Title]=@Title,
					[PersonId]=@PersonId,
					[Index]=@Index")
        {
        }
    }
}