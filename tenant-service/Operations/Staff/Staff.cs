using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Tenant.Operations.Staff
{
    public class Staff : BaseModelDto, IDropDown
    {
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public string? NationalNumber { get; set; }
        public int? GenderLookup { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
       public string Title {get; set;}
    }
}
