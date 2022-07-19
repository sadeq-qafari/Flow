using Core.Meteor.Dto;

namespace Identity.Operations.Database.Permission.Dtos
{
    public class PermissionUpdateInDto : DbUpdateInDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public int TypeLookup { get; set; }

    }
}
