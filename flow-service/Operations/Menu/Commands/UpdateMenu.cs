using Core.Meteor;
using Flow.Operations.Menu.Dto;

namespace Flow.Operations.Menu.Commands
{
    public class UpdateMenu : DbUpdateAsync<UpdateMenuInDto>
    {
        public UpdateMenu() : base("[Flow].[Menu]",
            "[Name]=@Name, [Title]=@Title, [ParentId]=@ParentId, [PermissionName]=@PermissionName, [Index]=@Index, [Link]=@Link, [Icon]=@Icon, [ColorHex]=@ColorHex")
        {
        }
    }
}
