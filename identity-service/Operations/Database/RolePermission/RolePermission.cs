using Core.Meteor;
using Core.Meteor.Dto;

namespace Identity.Operations.Database.RolePermission
{
    public class RolePermission : BaseModelDto, IDropDown
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public bool IsActive { get; set; }
       public string Title {get; set;}
    }
}
