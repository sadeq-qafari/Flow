using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Core.Operations.Model
{
    public class Model : BaseModelDto, IDropDown
    {
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
        public bool IsActive { get; set; }
    }
}
