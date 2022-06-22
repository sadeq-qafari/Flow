using Saanaa.Core.Meteor.Dto;

namespace Flow.Operations.FormProperty.Dtos
{
    public class FormPropertyAddInDto : SaanaaDbInsertInDto
    {
        public int LayoutIndex { get; set; }
        public string? Name { get; set; }
        public string Title { get; set; }
        public int FormId { get; set; }
        public string Type { get; set; }
        public int ElementId { get; set; }
        public bool IsRequired { get; set; }
        public bool IsAddable { get; set; }
        public bool IsUpdatable { get; set; }
        public bool IsFilterable { get; set; }
        public int IsHiddenInGrid { get; set; }
        public bool IsHiddenInForm { get; set; }
        public bool IsVisibleInDropdown { get; set; }
        public bool IsUnique { get; set; }
        public bool IsSensitiveToRepetition { get; set; }
        public bool IsComputed { get; set; }
        public string? Rules { get; set; }
        public int? RelatedFormId { get; set; }
        public int? RelatedFormPropertyId { get; set; }
        public int? LookupId { get; set; }
        public string? Hint { get; set; }
        public string? DefaultValue { get; set; }
        public string? CssStyle { get; set; }
        public string? Placeholder { get; set; }

    }
}
