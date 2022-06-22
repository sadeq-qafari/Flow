using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Core.Operations.Report
{
    public class Report : BaseModelDto, IDropDown
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Action { get; set; }
        public string Template { get; set; }
        public bool IsActive { get; set; }
        public bool IsReport { get; set; }

    }
}
