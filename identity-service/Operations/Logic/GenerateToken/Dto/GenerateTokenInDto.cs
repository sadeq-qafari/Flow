using Meteor.Operation.Db.Default;

namespace Identity.Operations.Logic.GenerateToken.Dto
{
    public class GenerateTokenInDto : IDbModel<long?>
    {
        public TokenGrantType Type { get; set; }
        public TokenUserType UserType { get; set; } = TokenUserType.User;
        public string? VerificationCode { get; set; }
        public string? Hash { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? RefreshToken { get; set; }
        public long? Id => long.TryParse(Username,out _) ? long.Parse(Username) : null;
    }
}
