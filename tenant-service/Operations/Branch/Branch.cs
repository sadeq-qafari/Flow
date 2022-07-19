using Core.Meteor;
using Core.Meteor.Dto;
using Core.Meteor.SqlServer;

namespace Tenant.Operations.Branch
{
    public class Branch : BaseModelDto, IDropDown
    {
        public int CityId { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? Address { get; set; }
        public GeoPoint? GeoLocation { get; set; }
        public string? PostalCode { get; set; }
        public bool IsActive { get; set; }

    }
}
