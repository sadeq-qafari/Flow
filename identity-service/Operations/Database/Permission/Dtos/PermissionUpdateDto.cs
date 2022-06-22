using Saanaa.Core.Meteor.Dto;

namespace Identity.Operations.Database.Permission.Dtos
{
    public class PermissionUpdateInDto : SaanaaDbUpdateInDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public int TypeLookup { get; set; }

    }
}
