using Core.Meteor;
using Core.Meteor.Dto;

namespace Core.Operations.Service
{
    public class Service : BaseModelDto, IDropDown
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }

    }
}
