using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Flow.Operations.FormPermission
{
    public class FormPermission : BaseModelDto, IDropDown
    {
        public int RoleId { get; set; }
        public int FormId { get; set; }
        public int PermissionTypeLookup { get; set; }
        public int? FormActionId { get; set; }
        public bool IsActive { get; set; }
       public string Title {get; set;}
    }
}
