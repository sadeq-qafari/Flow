using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Core.Operations.ModelReport
{
    public class ModelReport : BaseModelDto, IDropDown
    {
        public int ModelId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Layout { get; set; }
        public bool? IsLocked { get; set; }
        public int? ReportId { get; set; }
        public bool IsActive { get; set; }

    }
}
