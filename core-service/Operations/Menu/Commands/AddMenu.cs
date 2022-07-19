using System.Threading.Tasks;
using Core.Meteor;
using Core.Operations.Menu.Dto;

namespace Core.Operations.Menu.Commands
{
    public class AddMenu : DbInsertAsync<AddMenuInDto>
    {
        protected override Task PrepareExecutionAsync()
        {
            Input.TenantId = 0;
            return Task.CompletedTask;
        }

        public AddMenu() : base("[Core].[Menu]",
            "[Name], [Title], [ParentId], [PermissionName], [Index], [Link], [Icon], [ColorHex]",
            "@Name, @Title, @ParentId, @PermissionName, @Index, @Link, @Icon, @ColorHex")
        {
        }
    }
}

