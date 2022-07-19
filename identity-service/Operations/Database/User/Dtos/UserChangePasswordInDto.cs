using Meteor.Operation.Db.Default;
using Core.Meteor;

namespace Identity.Operations.Database.User.Dtos
{
    public class UserChangePasswordInDto : IHaveActionBy, IDbModel<int?>
    {
        public int ActionBy { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public int? Id => ActionBy;
    }
}
