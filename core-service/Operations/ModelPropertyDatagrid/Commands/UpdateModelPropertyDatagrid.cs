using Core.Meteor;
using Core.Operations.ModelPropertyDatagrid.Dto;

namespace Core.Operations.ModelPropertyDatagrid.Commands
{
    public class UpdateModelPropertyDatagrid : DbUpdateAsync<UpdateModelPropertyDatagridInDto>
    {
        public UpdateModelPropertyDatagrid() : base("[Core].[ModelPropertyDatagrid]",
            "[Index]=@Index, [Name]=@Name, [Visible]=@Visible, [Sortable]=@Sortable, [ViewType]=@ViewType, [Width]=@Width, [ReferenceUrl]=@ReferenceUrl, [Alignment]=@Alignment, [Css]=@Css, [HeaderCss]=@HeaderCss")
        {
        }
    }
}
