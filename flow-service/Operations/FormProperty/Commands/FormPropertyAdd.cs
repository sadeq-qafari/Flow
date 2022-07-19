using Core.Meteor;
using Flow.Operations.FormProperty.Dtos;

namespace Flow.Operations.FormProperty.Commands
{
    public class FormPropertyAdd : DbInsertAsync<FormPropertyAddInDto>
    {
        public FormPropertyAdd() : base("[Flow].[FormProperty]",
            @"[LayoutIndex],
						[Name],
						[Title],
						[FormId],
						[Type],
						[ElementId],
						[IsRequired],
						[IsAddable],
						[IsUpdatable],
						[IsFilterable],
						[IsHiddenInGrid],
						[IsHiddenInForm],
						[IsVisibleInDropdown],
						[IsUnique],
						[IsSensitiveToRepetition],
						[IsComputed],
						[Rules],
						[RelatedFormId],
						[RelatedFormPropertyId],
						[LookupId],
						[Hint],
						[DefaultValue],
						[CssStyle],
						[Placeholder]",
            @"@LayoutIndex,
						@Name,
						@Title,
						@FormId,
						@Type,
						@ElementId,
						@IsRequired,
						@IsAddable,
						@IsUpdatable,
						@IsFilterable,
						@IsHiddenInGrid,
						@IsHiddenInForm,
						@IsVisibleInDropdown,
						@IsUnique,
						@IsSensitiveToRepetition,
						@IsComputed,
						@Rules,
						@RelatedFormId,
						@RelatedFormPropertyId,
						@LookupId,
						@Hint,
						@DefaultValue,
						@CssStyle,
						@Placeholder")
        {
        }
    }
}

