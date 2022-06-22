using Saanaa.Core.Meteor.Dto;

namespace Core.Operations.ModelProperty.Dto
{
    public class UpdateModelPropertyInDto : SaanaaDbUpdateInDto
    {
        public int ModelId { get; set; }
        public string? ModelTitle { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string? ValidationRegex { get; set; }
        public int? ViewSize { get; set; }
        public int? ModelPropertyDatagridId { get; set; }
        public string? ModelPropertyDatagridTitle { get; set; }
        public int? ModelPropertyElementId { get; set; }
        public string? ModelPropertyElementTitle { get; set; }
        public int? ModelPropertyFilterId { get; set; }
        public string? ModelPropertyFilterTitle { get; set; }
        public int? RelatedModelId { get; set; }
        public string? RelatedModelTitle { get; set; }
        public int? RelatedModelPropertyId { get; set; }
        public string? RelatedModelPropertyTitle { get; set; }
        public string? DefaultValue { get; set; }
        public string? LabelFieldName { get; set; }
        public bool? IsRequired { get; set; }
        public bool? IsLtr { get; set; }
        public bool Visible { get; set; }
        public bool Insertable { get; set; }
        public bool Updatable { get; set; }
        public bool Filterable { get; set; }

    }
}
