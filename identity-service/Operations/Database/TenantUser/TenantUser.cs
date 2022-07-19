using Core.Meteor;
using Core.Meteor.Dto;

namespace Identity.Operations.Database.TenantUser
{
    public class TenantUser : BaseModelDto, IDropDown
    {
        public int? BranchId { get; set; }
        public int UserId { get; set; }
        public bool IsBanned { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
       public string Title {get; set;}
    }
}
