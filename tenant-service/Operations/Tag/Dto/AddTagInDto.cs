using Saanaa.Core.Meteor.Dto;

namespace Tenant.Operations.Tag.Dto
{
    public class AddTagInDto : SaanaaDbInsertInDto
    {
        public string Title { get; set; }

    }
}
