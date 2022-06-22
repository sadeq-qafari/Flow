using Saanaa.Core.Meteor.Dto;

namespace Core.Operations.ServiceConfig.Dto
{
    public class UpdateServiceConfigInDto : SaanaaDbUpdateInDto
    {
        public string ServiceName { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

    }
}
