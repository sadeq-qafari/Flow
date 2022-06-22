using NodaTime;
using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Identity.Operations.Database.TenantService
{
    public class TenantService : BaseModelDto, IDropDown
    {
        public int ServiceId { get; set; }
        public Instant ExpireDate { get; set; }
        public bool IsActive { get; set; }
       public string Title {get; set;}
    }
}
