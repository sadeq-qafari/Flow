using Meteor.Operation.Db.Default;

namespace Identity.Operations.Logic.ValidateVerificationCode.Dto
{
    public class ValidateVerificationCodeInDto : IDbModel<long?>
    {
        public string Username { get; set; }
        public string Code { get; set; }
        public long? Id => long.TryParse(Username, out _) ? long.Parse(Username) : null;
    }
}
