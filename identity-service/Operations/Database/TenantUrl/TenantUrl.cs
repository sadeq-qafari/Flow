using Core.Meteor;
using Core.Meteor.Dto;

namespace Identity.Operations.Database.TenantUrl
{
    public class TenantUrl : BaseModelDto, IDropDown
    {
        public int TypeLookup { get; set; }
        public string Url { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
       public string Title {get; set;}
    }
}
