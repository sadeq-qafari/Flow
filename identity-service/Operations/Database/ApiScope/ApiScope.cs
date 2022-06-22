using System.Collections.Generic;
using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Identity.Operations.Database.ApiScope
{
    public class ApiScope : BaseModelDto, IDropDown
    {
        public string Name { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public bool Required { get; set; }
        public bool Emphasize { get; set; }
        public bool ShowInDiscoveryDocument { get; set; }
        public int ApiResourceId { get; set; }
        public string? Claims { get; set; }
        public Dictionary<string, string>? Properties { get; set; }
        public bool Enabled { get; set; }
        public string Title => Name;
    }
}
