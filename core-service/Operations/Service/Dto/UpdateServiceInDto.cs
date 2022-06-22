using Saanaa.Core.Meteor.Dto;

namespace Core.Operations.Service.Dto
{
    public class UpdateServiceInDto : SaanaaDbUpdateInDto
    {
        public string Name { get; set; }
        public string Title { get; set; }

    }
}
