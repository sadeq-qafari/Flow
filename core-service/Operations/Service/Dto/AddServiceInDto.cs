using Core.Meteor.Dto;

namespace Core.Operations.Service.Dto
{
    public class AddServiceInDto : DbInsertInDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
    }
}
