using Core.Meteor.Dto;

namespace Core.Operations.ServiceConfig.Dto
{
    public class AddServiceConfigInDto : DbInsertInDto
    {
        public string ServiceName { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

    }
}
