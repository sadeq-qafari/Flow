namespace Identity.Operations.Database.User.Dtos
{
    public class CheckUserInDto
    {
        public string Username { get; set; }
        public int TenantId { get; set; }
    }
}
