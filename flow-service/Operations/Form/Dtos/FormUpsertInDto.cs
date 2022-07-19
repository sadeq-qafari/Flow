using System.Collections.Generic;
using Core.Meteor;

namespace Flow.Operations.Form.Dtos
{
    public class FormUpsertInDto : IHaveTenant, IHaveActionBy
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Layout { get; set; }
        public bool? IsAddable { get; set; }
        public bool? IsUpdatable { get; set; }
        public bool? IsDeletable { get; set; }
        public bool IsActive { get; set; }
        public int? TenantId { get; set; }
        public int ActionBy { get; set; }
        public List<FormPropertyItem?> Items { get; set; }
        public List<FormActionItem?> ActionItems { get; set; }
    }

    public class FormPropertyItem
    {
        public int Id { get; set; }
        public int LayoutIndex { get; set; }
        public string? Name { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int ElementId { get; set; }
        public bool IsRequired { get; set; }
        public bool IsAddable { get; set; }
        public bool IsUpdatable { get; set; }
        public bool IsFilterable { get; set; }
        public bool IsHiddenInGrid { get; set; }
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
        public bool IsActive { get; set; }
    }

    public class FormActionItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? ColorHex { get; set; }
        public int TypeLookup { get; set; }
        public string? Script { get; set; }
        public bool IsActive { get; set; }
    }
}
