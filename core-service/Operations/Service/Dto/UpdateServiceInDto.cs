using Core.Meteor.Dto;

namespace Core.Operations.Service.Dto
{
    public class UpdateServiceInDto : DbUpdateInDto
    {
        public string Name { get; set; }
        public string Title { get; set; }

    }
}
