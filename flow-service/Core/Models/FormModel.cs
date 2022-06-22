using System.Collections.Generic;

namespace Flow.Core.Models
{
    public class FormModel
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
        public List<FormPropertyModel>? Properties { get; set; }
        public List<FormActionModel?>? Actions { get; set; }
    }
}
