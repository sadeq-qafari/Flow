using Flow.Operations.Menu.Dto;
using Saanaa.Core.Meteor;

namespace Flow.Operations.Menu.Commands
{
    public class UpdateMenu : SaanaaDbUpdateAsync<UpdateMenuInDto>
    {
        public UpdateMenu() : base("[Flow].[Menu]",
            "[Name]=@Name, [Title]=@Title, [ParentId]=@ParentId, [PermissionName]=@PermissionName, [Index]=@Index, [Link]=@Link, [Icon]=@Icon, [ColorHex]=@ColorHex")
        {
        }
    }
}
