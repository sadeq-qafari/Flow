using System.Threading.Tasks;
using Core.Operations.ModelProperty.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.ModelProperty.Commands
{
    public class AddModelProperty : SaanaaDbInsertAsync<AddModelPropertyInDto>
    {
        protected override Task PrepareExecutionAsync()
        {
            Input.TenantId = 0;
            return Task.CompletedTask;
        }

        public AddModelProperty() : base("[Core].[ModelProperty]",
            "[ModelId], [Index], [Name], [Title], [Type], [ValidationRegex], [ViewSize], [ModelPropertyDatagridId], [ModelPropertyElementId], [ModelPropertyFilterId], [RelatedModelId], [RelatedModelPropertyId], [DefaultValue], [IsRequired], [IsLtr], [Visible], [Insertable], [Updatable], [Filterable], [LabelFieldName]",
            "@ModelId, @Index, @Name, @Title, @Type, @ValidationRegex, @ViewSize, @ModelPropertyDatagridId, @ModelPropertyElementId, @ModelPropertyFilterId, @RelatedModelId, @RelatedModelPropertyId, @DefaultValue, @IsRequired, @IsLtr, @Visible, @Insertable, @Updatable, @Filterable, @LabelFieldName")
        {
        }
    }
}

