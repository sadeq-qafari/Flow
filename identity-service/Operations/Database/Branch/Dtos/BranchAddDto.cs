using Saanaa.Core.Meteor.Dto;

namespace Identity.Operations.Database.Branch.Dtos
{
    public class BranchAddInDto : SaanaaDbInsertInDto
    {
        public int? ParentId { get; set; }
        public string Title { get; set; }

    }
}
