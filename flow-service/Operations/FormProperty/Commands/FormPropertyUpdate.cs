using Core.Meteor;
using Flow.Operations.FormProperty.Dtos;

namespace Flow.Operations.FormProperty.Commands
{
    public class FormPropertyUpdate : DbUpdateAsync<FormPropertyUpdateInDto>
    {
        public FormPropertyUpdate() : base("[Flow].[FormProperty]",
            @"[LayoutIndex]=@LayoutIndex,
					[Name]=@Name,
					[Title]=@Title,
					[FormId]=@FormId,
					[Type]=@Type,
					[ElementId]=@ElementId,
					[IsRequired]=@IsRequired,
					[IsAddable]=@IsAddable,
					[IsUpdatable]=@IsUpdatable,
					[IsFilterable]=@IsFilterable,
					[IsHiddenInGrid]=@IsHiddenInGrid,
					[IsHiddenInForm]=@IsHiddenInForm,
					[IsVisibleInDropdown]=@IsVisibleInDropdown,
					[IsUnique]=@IsUnique,
					[IsSensitiveToRepetition]=@IsSensitiveToRepetition,
					[IsComputed]=@IsComputed,
					[Rules]=@Rules,
					[RelatedFormId]=@RelatedFormId,
					[RelatedFormPropertyId]=@RelatedFormPropertyId,
					[LookupId]=@LookupId,
					[Hint]=@Hint,
					[DefaultValue]=@DefaultValue,
					[CssStyle]=@CssStyle,
					[Placeholder]=@Placeholder")
        {
        }
    }
}
