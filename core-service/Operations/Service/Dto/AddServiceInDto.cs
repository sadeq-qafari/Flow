using Saanaa.Core.Meteor.Dto;

namespace Core.Operations.Service.Dto
{
    public class AddServiceInDto : SaanaaDbInsertInDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
    }
}
