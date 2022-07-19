using System.Collections.Generic;

namespace Core.Meteor.Models
{
    public class Model
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public bool HasCustomUpsertForm { get; set; }
        public bool Insert { get; set; }
        public bool Read { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public string? JsInputMapper { get; set; }
        public string? JsOutputMapper { get; set; }
        public string? JsController { get; set; }
        public bool IsReport { get; set; }
        public string? ReportQuery { get; set; }
        public int? ReportDbServerId { get; set; }
        public List<ModelProperty> Properties { get; set; } = new List<ModelProperty>();
        public List<RelatedModel> RelatedModels { get; set; } = new List<RelatedModel>();
        public List<ModelFilter> Filters { get; set; } = new List<ModelFilter>();
    }
}
