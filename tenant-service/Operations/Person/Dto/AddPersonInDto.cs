using Saanaa.Core.Meteor.Dto;

namespace Tenant.Operations.Person.Dto
{
    public class AddPersonInDto : SaanaaDbInsertInDto
    {
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public string? NationalNumber { get; set; }
        public int? GenderLookup { get; set; }
        public string? Description { get; set; }

    }
}
