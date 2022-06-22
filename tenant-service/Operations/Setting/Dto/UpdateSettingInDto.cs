using Saanaa.Core.Meteor.Dto;

namespace Tenant.Operations.Setting.Dto
{
    public class UpdateSettingInDto : SaanaaDbUpdateInDto
    {
        public string Title { get; set; }
        public string ServiceName { get; set; }
        public string Name { get; set; }
        public int TypeLookup { get; set; }
        public string Value { get; set; }
        public string Options { get; set; }
        public string RecommendedValue { get; set; }

    }
}
