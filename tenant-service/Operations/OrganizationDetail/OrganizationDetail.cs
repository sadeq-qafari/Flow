using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Tenant.Operations.OrganizationDetail
{
    public class OrganizationDetail : BaseModelDto, IDropDown
    {
        public string? Name { get; set; }
        public string? Value { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
       public string Title {get; set;}
    }
}
