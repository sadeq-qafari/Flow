using Core.Meteor;
using Core.Meteor.Dto;

namespace Identity.Operations.Database.DeviceCode
{
    public class DeviceCode : BaseModelDto, IDropDown
    {

       public string Title {get; set;}
    }
}
