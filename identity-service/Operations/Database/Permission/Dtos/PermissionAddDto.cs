using Core.Meteor.Dto;

namespace Identity.Operations.Database.Permission.Dtos
{
    public class PermissionAddInDto : DbInsertInDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public int TypeLookup { get; set; }

    }
}
