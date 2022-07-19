using Core.Meteor;
using Core.Meteor.Dto;

namespace Tenant.Operations.Person
{
    public class Person : BaseModelDto, IDropDown
    {
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public string? NationalNumber { get; set; }
        public int? GenderLookup { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public string Title => $"{FirstName} {LastName}";
    }
}
