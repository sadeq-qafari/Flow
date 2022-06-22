using Saanaa.Core.Meteor.Dto;

namespace Core.Operations.EntityRelation.Dto
{
    public class AddEntityRelationInDto : SaanaaDbInsertInDto
    {
        public int ModelIdA { get; set; }
        public int EntityIdA { get; set; }
        public int ModelIdB { get; set; }
        public int EntityIdB { get; set; }

    }
}
