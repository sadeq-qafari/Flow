using Core.Meteor;
using Flow.Operations.Menu.Dto;

namespace Flow.Operations.Menu.Commands
{
    public class AddMenu : DbInsertAsync<AddMenuInDto>
    {
        public AddMenu() : base("[Flow].[Menu]",
            "[Name], [Title], [ParentId], [PermissionName], [Index], [Link], [Icon], [ColorHex]",
            "@Name, @Title, @ParentId, @PermissionName, @Index, @Link, @Icon, @ColorHex")
        {
        }
    }
}

