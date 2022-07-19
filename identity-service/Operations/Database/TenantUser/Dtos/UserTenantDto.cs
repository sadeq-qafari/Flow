using System.Collections.Generic;
using Core.Meteor.Dto;

namespace Identity.Operations.Database.TenantUser.Dtos
{
    public class UserTenantDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int BranchId { get; set; }
        public string? BranchTitle { get; set; }
        public int UserId { get; set; }
        public Dictionary<string,string>? BaseUrls { get; set; }
        public bool IsDefault { get; set; }
        public int? RoleCount { get; set; }

        public ImageInfoJson? Logo { get; set; }
    }
}
