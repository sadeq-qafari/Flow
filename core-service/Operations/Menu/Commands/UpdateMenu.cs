using Core.Operations.Menu.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.Menu.Commands
{
    public class UpdateMenu : SaanaaDbUpdateAsync<UpdateMenuInDto>
    {
        public UpdateMenu() : base("[Core].[Menu]",
            "[Name]=@Name, [Title]=@Title, [ParentId]=@ParentId, [PermissionName]=@PermissionName, [Index]=@Index, [Link]=@Link, [Icon]=@Icon, [ColorHex]=@ColorHex")
        {
        }
    }
}
