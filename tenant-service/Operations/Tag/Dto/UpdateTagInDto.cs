using Core.Meteor.Dto;

namespace Tenant.Operations.Tag.Dto
{
    public class UpdateTagInDto : DbUpdateInDto
    {
        public string Title { get; set; }

    }
}
