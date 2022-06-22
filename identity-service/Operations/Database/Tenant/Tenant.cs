using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Identity.Operations.Database.Tenant
{
    public class Tenant : BaseModelDto, IDropDown
    {
        public string? Name { get; set; }
        public string? Title { get; set; }
        public bool IsActive { get; set; }

    }
}
