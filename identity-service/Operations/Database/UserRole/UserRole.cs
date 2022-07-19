using Core.Meteor;
using Core.Meteor.Dto;

namespace Identity.Operations.Database.UserRole
{
    public class UserRole : BaseModelDto, IDropDown
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int? BranchId { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
       public string Title {get; set;}
    }
}
