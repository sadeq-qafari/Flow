using Core.Meteor;
using Core.Operations.Menu.Dto;

namespace Core.Operations.Menu.Commands
{
    public class UpdateMenu : DbUpdateAsync<UpdateMenuInDto>
    {
        public UpdateMenu() : base("[Core].[Menu]",
            "[Name]=@Name, [Title]=@Title, [ParentId]=@ParentId, [PermissionName]=@PermissionName, [Index]=@Index, [Link]=@Link, [Icon]=@Icon, [ColorHex]=@ColorHex")
        {
        }
    }
}
