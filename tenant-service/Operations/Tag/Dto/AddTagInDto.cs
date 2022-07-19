using Core.Meteor.Dto;

namespace Tenant.Operations.Tag.Dto
{
    public class AddTagInDto : DbInsertInDto
    {
        public string Title { get; set; }

    }
}
