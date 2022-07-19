using Core.Meteor.Dto;

namespace Tenant.Operations.Staff.Dtos
{
    public class StaffUpdateInDto : DbUpdateInDto
    {
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public string? NationalNumber { get; set; }
        public int? GenderLookup { get; set; }
        public string? Description { get; set; }

    }
}
