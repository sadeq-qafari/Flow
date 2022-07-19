using NodaTime;
using Core.Meteor.Dto;
using Core.Meteor.SqlServer;

namespace Tenant.Operations.Branch.Dtos
{
    public class BranchAddInDto : DbInsertInDto
    {

        public string Title { get; set; }
        public string FinancialYearTitle { get; set; }
        public Instant FinancialYearFromDate { get; set; }
        public Instant FinancialYearToDate { get; set; }
        public int CityId { get; set; }
        public int? ParentId { get; set; }
        public string? Address { set; get; }
        public GeoPoint? GeoLocation { get; set; }
        public string? PostalCode { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }

    }
}
