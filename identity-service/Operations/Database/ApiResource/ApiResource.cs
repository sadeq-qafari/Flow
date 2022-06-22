using System.Collections.Generic;
using IdentityServer4.Models;
using NodaTime;
using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Identity.Operations.Database.ApiResource
{
    public class ApiResource : BaseModelDto, IDropDown
    {
        public bool Enabled { get; set; }
        public string Name { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public Instant Created { get; set; }
        public Instant? Updated { get; set; }
        public Instant? LastAccessed { get; set; }
        public bool NonEditable { get; set; }
        public bool ShowInDiscoveryDocument { get; set; }
        public string? AllowedAccessTokenSigningAlgorithms { get; set; }
        public Dictionary<string, string>? Properties { get; set; }
        public string? Claims { get; set; }
        public string? Scopes { get; set; }
        public List<Secret> Secrets { get; set; }

        public string Title => Name;
    }
}
