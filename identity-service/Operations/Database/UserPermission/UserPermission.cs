using Core.Meteor;
using Core.Meteor.Dto;

namespace Identity.Operations.Database.UserPermission
{
    public class UserPermission : BaseModelDto, IDropDown
    {
        public int UserId { get; set; }
        public int PermissionId { get; set; }
        public int? BranchId { get; set; }
        public bool IsGranted { get; set; }
        public bool IsActive { get; set; }
       public string Title {get; set;}
    }
}
