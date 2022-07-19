namespace Core.AspNetCore.Security
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public int? BranchId { get; set; }
        public int? TenantId { get; set; }
    }
}
