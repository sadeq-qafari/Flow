using System.Collections.Generic;
using IdentityServer4.Models;
using NodaTime;
using Core.Meteor;
using Core.Meteor.Dto;

namespace Identity.Operations.Database.Client
{
    public class Client : BaseModelDto, IDropDown
    {
        public bool Enabled { get; set; }
        public string ClientId { get; set; }
        public string ProtocolType { get; set; }
        public bool RequireClientSecret { get; set; }
        public string? ClientName { get; set; }
        public string? Description { get; set; }
        public string? ClientUri { get; set; }
        public string? LogoUri { get; set; }
        public bool RequireConsent { get; set; }
        public bool AllowRememberConsent { get; set; }
        public bool AlwaysIncludeUserClaimsInIdToken { get; set; }
        public bool RequirePkce { get; set; }
        public bool RequireRequestObject { get; set; }
        public bool AllowPlainTextPkce { get; set; }
        public bool AllowAccessTokensViaBrowser { get; set; }
        public string? FrontChannelLogoutUri { get; set; }
        public bool FrontChannelLogoutSessionRequired { get; set; }
        public string? BackChannelLogoutUri { get; set; }
        public bool BackChannelLogoutSessionRequired { get; set; }
        public bool AllowOfflineAccess { get; set; }
        public int IdentityTokenLifetime { get; set; }
        public int AccessTokenLifetime { get; set; }
        public int AuthorizationCodeLifetime { get; set; }
        public int? ConsentLifetime { get; set; }
        public int AbsoluteRefreshTokenLifetime { get; set; }
        public int SlidingRefreshTokenLifetime { get; set; }
        public int RefreshTokenUsage { get; set; }
        public bool UpdateAccessTokenClaimsOnRefresh { get; set; }
        public int RefreshTokenExpiration { get; set; }
        public int AccessTokenType { get; set; }
        public bool EnableLocalLogin { get; set; }
        public bool IncludeJwtId { get; set; }
        public bool AlwaysSendClientClaims { get; set; }
        public string? ClientClaimsPrefix { get; set; }
        public string? PairWiseSubjectSalt { get; set; }
        public Instant Created { get; set; }
        public Instant? Updated { get; set; }
        public Instant? LastAccessed { get; set; }
        public int? UserSsoLifetime { get; set; }
        public string? UserCodeType { get; set; }
        public int DeviceCodeLifetime { get; set; }
        public bool NonEditable { get; set; }
        public bool? IsPublic { get; set; }
        public string? Scopes { get; set; }
        public List<Secret> Secrets { get; set; }
        public string? RedirectUris { get; set; }
        public Dictionary<string, string>? Properties { get; set; }
        public string? PostLogoutRedirectUris { get; set; }
        public string? IdPRestrictions { get; set; }
        public string? GrantTypes { get; set; }
        public string? CorsOrigins { get; set; }
        public List<ClientClaim>? Claims { get; set; }
       public string Title {get; set;}
       public string? AllowedIdentityTokenSigningAlgorithms {get; set;}
    }
}
