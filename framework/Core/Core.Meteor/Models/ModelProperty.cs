using System.Collections.Generic;

namespace Core.Meteor.Models
{
    public class ModelProperty
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string ValidationRegex { get; set; }
        public bool Visible { get; set; }
        public string ViewSize { get; set; }
        public bool Insertable { get; set; }
        public bool Updatable { get; set; }
        public bool Filterable { get; set; }
        public bool? IsLtr { get; set; }
        public string? DefaultValue { get; set; }
        public string? LabelFieldName { get; set; }
        public bool IsRequired { get; set; }
        public int? ModelPropertyDataGridId { get; set; }
        public int? ModelPropertyFilterId { get; set; }
        public int? ModelPropertyElementId { get; set; }
        public int? RelatedModelId { get; set; }
        public int? RelatedModelPropertyId { get; set; }
        public string? RelatedModelUrl { get; set; }

        public ModelPropertyDataGrid DataGrid { get; set; }
        public ModelPropertyElement Element { get; set; }
        public List<ModelPropertyLookup> LookupOptions { get; set; }
    }
}
