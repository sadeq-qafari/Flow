using System.Collections.Generic;
using Core.Meteor.Dto;

namespace Core.Meteor.Models
{
    public class Tenant : BaseModelDto, IDropDown
    {
        public string? Name { get; set; }
        public string? Title { get; set; }
        public int? ApplicationId { get; set; }
        public Dictionary<string,string> Urls { get; set; }
        public decimal Credit { get; set; }
    }

    public class TenantUrl
    {
        public int TenantId { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
    }

    public class TenantCredit
    {
        public int TenantId { get; set; }
        public decimal Credit { get; set; }
    }
}
