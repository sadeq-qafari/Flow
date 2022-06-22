using Core.Operations.ModelPropertyDatagrid.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.ModelPropertyDatagrid.Commands
{
    public class UpdateModelPropertyDatagrid : SaanaaDbUpdateAsync<UpdateModelPropertyDatagridInDto>
    {
        public UpdateModelPropertyDatagrid() : base("[Core].[ModelPropertyDatagrid]",
            "[Index]=@Index, [Name]=@Name, [Visible]=@Visible, [Sortable]=@Sortable, [ViewType]=@ViewType, [Width]=@Width, [ReferenceUrl]=@ReferenceUrl, [Alignment]=@Alignment, [Css]=@Css, [HeaderCss]=@HeaderCss")
        {
        }
    }
}
