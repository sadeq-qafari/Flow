namespace Core.Meteor.Dto
{
    public class DbInsertInDto : IAmDbInsert
    {
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int? TenantId { get; set; }
    }
}
