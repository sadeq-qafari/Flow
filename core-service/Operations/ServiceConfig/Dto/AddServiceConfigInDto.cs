using Saanaa.Core.Meteor.Dto;

namespace Core.Operations.ServiceConfig.Dto
{
    public class AddServiceConfigInDto : SaanaaDbInsertInDto
    {
        public string ServiceName { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

    }
}
