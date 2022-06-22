using NodaTime;
using Saanaa.Core.Meteor.Dto;

namespace Identity.Operations.Database.User.Dtos
{
    public class UserUpdateInDto : SaanaaDbUpdateInDto
    {
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? NationalCode { get; set; }
        public string? Password { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Instant? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }

    }
}
