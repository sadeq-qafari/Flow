using Core.Meteor.Dto;
using Core.Meteor.SqlServer;

namespace Tenant.Operations.Branch.Dtos
{
    public class BranchUpdateInDto : DbUpdateInDto
    {
        public string Title { get; set; }
        public int CityId { get; set; }
        public int? ParentId { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? Address { get; set; }
        public GeoPoint? GeoLocation { get; set; }
        public string? PostalCode { get; set; }

    }
}
