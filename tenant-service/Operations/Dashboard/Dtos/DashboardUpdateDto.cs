using Core.Meteor.Dto;

namespace Tenant.Operations.Dashboard.Dtos
{
    public class DashboardUpdateInDto : DbUpdateInDto
    {
        public string? Title { get; set; }
        public int? PersonId { get; set; }
        public int Index { get; set; }

    }
}
