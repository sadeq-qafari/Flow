namespace Identity.Operations.Logic.GenerateToken
{
    public enum TokenGrantType
    {
        Hash = 0,
        UsernamePassword,
        VerificationCode,
        Refresh
    }

    public enum TokenUserType
    {
        Admin = 0,
        User
    }
}
