using System.Threading.Tasks;
using Core.Meteor;
using Core.Operations.ModelPropertyDatagrid.Dto;

namespace Core.Operations.ModelPropertyDatagrid.Commands
{
    public class AddModelPropertyDatagrid : DbInsertAsync<AddModelPropertyDatagridInDto>
    {
        protected override Task PrepareExecutionAsync()
        {
            Input.TenantId = 0;
            return Task.CompletedTask;
        }

        public AddModelPropertyDatagrid() : base("[Core].[ModelPropertyDatagrid]",
            "[Index], [Name], [Visible], [Sortable], [ViewType], [Width], [ReferenceUrl], [Alignment], [Css], [HeaderCss]",
            "@Index, @Name, @Visible, @Sortable, @ViewType, @Width, @ReferenceUrl, @Alignment, @Css, @HeaderCss")
        {
        }
    }
}

