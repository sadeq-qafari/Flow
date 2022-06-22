using Flow.Operations.Menu.Dto;
using Saanaa.Core.Meteor;

namespace Flow.Operations.Menu.Commands
{
    public class AddMenu : SaanaaDbInsertAsync<AddMenuInDto>
    {
        public AddMenu() : base("[Flow].[Menu]",
            "[Name], [Title], [ParentId], [PermissionName], [Index], [Link], [Icon], [ColorHex]",
            "@Name, @Title, @ParentId, @PermissionName, @Index, @Link, @Icon, @ColorHex")
        {
        }
    }
}

