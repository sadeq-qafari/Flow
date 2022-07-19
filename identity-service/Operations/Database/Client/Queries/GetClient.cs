using System.Threading.Tasks;
using IdentityServer4.Models;
using Meteor.Operation.Db;

namespace Identity.Operations.Database.Client.Queries
{
    public class GetClient : DbOperationAsync<string, IdentityServer4.Models.Client>
    {
        protected override async Task ExecutionAsync()
        {
            var client = await NewSql(sql => sql
                        .Select("[Identity].[Client]")
                        .Where("ClientId=@ClientId"),
                    new {ClientId = Input})
                .QueryFirstOrDefaultAsync<Client>();

            Output = new IdentityServer4.Models.Client
            {
                AbsoluteRefreshTokenLifetime = client.AbsoluteRefreshTokenLifetime,
                AccessTokenLifetime = client.AccessTokenLifetime,
                AccessTokenType = (AccessTokenType) client.AccessTokenType,
                AllowAccessTokensViaBrowser = client.AllowAccessTokensViaBrowser,
                AllowedCorsOrigins = client.CorsOrigins?.Split(','),
                AllowedGrantTypes = client.GrantTypes?.Split(','),
                AllowedIdentityTokenSigningAlgorithms = client.AllowedIdentityTokenSigningAlgorithms?.Split(','),
                AllowedScopes = client.Scopes?.Split(','),
                AllowOfflineAccess = client.AllowOfflineAccess,
                AllowPlainTextPkce = client.AllowPlainTextPkce,
                AllowRememberConsent = client.AllowRememberConsent,
                AlwaysIncludeUserClaimsInIdToken = client.AlwaysIncludeUserClaimsInIdToken,
                AlwaysSendClientClaims = client.AlwaysSendClientClaims,
                AuthorizationCodeLifetime = client.AuthorizationCodeLifetime,
                BackChannelLogoutSessionRequired = client.BackChannelLogoutSessionRequired,
                BackChannelLogoutUri = client.BackChannelLogoutUri,
                Claims = client.Claims,
                ClientClaimsPrefix = client.ClientClaimsPrefix,
                ClientId = client.ClientId,
                ClientName = client.ClientName,
                ClientSecrets = client.Secrets,
                ClientUri = client.ClientUri,
                ConsentLifetime = client.ConsentLifetime,
                Description = client.Description,
                DeviceCodeLifetime = client.DeviceCodeLifetime,
                Enabled = client.Enabled,
                EnableLocalLogin = client.EnableLocalLogin,
                FrontChannelLogoutSessionRequired = client.FrontChannelLogoutSessionRequired,
                FrontChannelLogoutUri = client.FrontChannelLogoutUri,
                IdentityProviderRestrictions = client.IdPRestrictions?.Split(','),
                IdentityTokenLifetime = client.IdentityTokenLifetime,
                IncludeJwtId = client.IncludeJwtId,
                LogoUri = client.LogoUri,
                PairWiseSubjectSalt = client.PairWiseSubjectSalt,
                PostLogoutRedirectUris = client.PostLogoutRedirectUris?.Split(','),
                Properties = client.Properties,
                ProtocolType = client.ProtocolType,
                RedirectUris = client.RedirectUris?.Split(','),
                RefreshTokenExpiration = (TokenExpiration) client.RefreshTokenExpiration,
                RefreshTokenUsage = (TokenUsage) client.RefreshTokenUsage,
                RequireClientSecret = client.RequireClientSecret,
                RequireConsent = client.RequireConsent,
                RequirePkce = client.RequirePkce,
                RequireRequestObject = client.RequireRequestObject,
                SlidingRefreshTokenLifetime = client.SlidingRefreshTokenLifetime,
                UpdateAccessTokenClaimsOnRefresh = client.UpdateAccessTokenClaimsOnRefresh,
                UserCodeType = client.UserCodeType,
                UserSsoLifetime = client.UserSsoLifetime
            };
        }
    }
}
