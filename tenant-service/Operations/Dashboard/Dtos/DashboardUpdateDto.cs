using Saanaa.Core.Meteor.Dto;

namespace Tenant.Operations.Dashboard.Dtos
{
    public class DashboardUpdateInDto : SaanaaDbUpdateInDto
    {
        public string? Title { get; set; }
        public int? PersonId { get; set; }
        public int Index { get; set; }

    }
}
