using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Core.Operations.ServiceConfig
{
    public class ServiceConfig : BaseModelDto, IDropDown
    {
        public string ServiceName { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
       public string Title {get; set;}
    }
}
