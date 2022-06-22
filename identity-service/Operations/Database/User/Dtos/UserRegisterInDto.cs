using Meteor.Operation.Db.Default;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.User.Dtos
{
    public class UserRegisterInDto : IHaveTenant, IHaveCreatedBy, IDbModel<long?>
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public string? NationalCode { get; set; }
        public int? TenantId { get; set; }
        public int? BranchId { get; set; }
        public int CreatedBy { get; set; }
        public long? Id => long.TryParse(Username, out _) ? long.Parse(Username) : null;
    }
}
