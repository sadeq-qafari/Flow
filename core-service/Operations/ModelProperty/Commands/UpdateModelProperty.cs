using Core.Operations.ModelProperty.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.ModelProperty.Commands
{
    public class UpdateModelProperty : SaanaaDbUpdateAsync<UpdateModelPropertyInDto>
    {
        public UpdateModelProperty() : base("[Core].[ModelProperty]",
            "[ModelId]=@ModelId, [Index]=@Index, [Name]=@Name, [Title]=@Title, [Type]=@Type, [ValidationRegex]=@ValidationRegex, [ViewSize]=@ViewSize, [ModelPropertyDatagridId]=@ModelPropertyDatagridId, [ModelPropertyElementId]=@ModelPropertyElementId, [ModelPropertyFilterId]=@ModelPropertyFilterId, [RelatedModelId]=@RelatedModelId, [RelatedModelPropertyId]=@RelatedModelPropertyId, [DefaultValue]=@DefaultValue, [IsRequired]=@IsRequired, [IsLtr]=@IsLtr, [Visible]=@Visible, [Insertable]=@Insertable, [Updatable]=@Updatable, [Filterable]=@Filterable, [LabelFieldName]=@LabelFieldName")
        {
        }
    }
}
