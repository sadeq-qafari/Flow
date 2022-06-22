using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.RolePermission.Dtos
{
    public class RolePermissionMergeInDto : IHaveActionBy
    {
        public PermissionCheckList PermissionCheckList { get; set; }
        public int RoleId { get; set; }
        public int ActionBy { get; set; }
    }
}
