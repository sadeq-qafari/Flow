using Core.Meteor.Dto;

namespace Identity.Operations.Database.Branch.Dtos
{
    public class BranchAddInDto : DbInsertInDto
    {
        public int? ParentId { get; set; }
        public string Title { get; set; }

    }
}
