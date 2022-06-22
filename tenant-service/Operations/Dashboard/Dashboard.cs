using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Tenant.Operations.Dashboard
{
    public class Dashboard : BaseModelDto, IDropDown
    {
        public string? Title { get; set; }
        public int? PersonId { get; set; }
        public int Index { get; set; }
        public bool IsActive { get; set; }

    }
}
