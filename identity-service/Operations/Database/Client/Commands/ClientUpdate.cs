using Identity.Operations.Database.Client.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Client.Commands
{
    public class ClientUpdate : SaanaaDbUpdateAsync<ClientUpdateInDto>
    {
        public ClientUpdate() : base("[Identity].[Client]",
            @"[Enabled]=@Enabled,
					[ClientId]=@ClientId,
					[ProtocolType]=@ProtocolType,
					[RequireClientSecret]=@RequireClientSecret,
					[ClientName]=@ClientName,
					[Description]=@Description,
					[ClientUri]=@ClientUri,
					[LogoUri]=@LogoUri,
					[RequireConsent]=@RequireConsent,
					[AllowRememberConsent]=@AllowRememberConsent,
					[AlwaysIncludeUserClaimsInIdToken]=@AlwaysIncludeUserClaimsInIdToken,
					[RequirePkce]=@RequirePkce,
					[AllowPlainTextPkce]=@AllowPlainTextPkce,
					[AllowAccessTokensViaBrowser]=@AllowAccessTokensViaBrowser,
					[FrontChannelLogoutUri]=@FrontChannelLogoutUri,
					[FrontChannelLogoutSessionRequired]=@FrontChannelLogoutSessionRequired,
					[BackChannelLogoutUri]=@BackChannelLogoutUri,
					[BackChannelLogoutSessionRequired]=@BackChannelLogoutSessionRequired,
					[AllowOfflineAccess]=@AllowOfflineAccess,
					[IdentityTokenLifetime]=@IdentityTokenLifetime,
					[AccessTokenLifetime]=@AccessTokenLifetime,
					[AuthorizationCodeLifetime]=@AuthorizationCodeLifetime,
					[ConsentLifetime]=@ConsentLifetime,
					[AbsoluteRefreshTokenLifetime]=@AbsoluteRefreshTokenLifetime,
					[SlidingRefreshTokenLifetime]=@SlidingRefreshTokenLifetime,
					[RefreshTokenUsage]=@RefreshTokenUsage,
					[UpdateAccessTokenClaimsOnRefresh]=@UpdateAccessTokenClaimsOnRefresh,
					[RefreshTokenExpiration]=@RefreshTokenExpiration,
					[AccessTokenType]=@AccessTokenType,
					[EnableLocalLogin]=@EnableLocalLogin,
					[IncludeJwtId]=@IncludeJwtId,
					[AlwaysSendClientClaims]=@AlwaysSendClientClaims,
					[ClientClaimsPrefix]=@ClientClaimsPrefix,
					[PairWiseSubjectSalt]=@PairWiseSubjectSalt,
					[Created]=@Created,
					[Updated]=@Updated,
					[LastAccessed]=@LastAccessed,
					[UserSsoLifetime]=@UserSsoLifetime,
					[UserCodeType]=@UserCodeType,
					[DeviceCodeLifetime]=@DeviceCodeLifetime,
					[NonEditable]=@NonEditable,
					[IsPublic]=@IsPublic,
					[Scopes]=@Scopes,
					[Secrets]=@Secrets,
					[RedirectUris]=@RedirectUris,
					[Properties]=@Properties,
					[PostLogoutRedirectUris]=@PostLogoutRedirectUris,
					[IdPRestrictions]=@IdPRestrictions,
					[GrantTypes]=@GrantTypes,
					[CorsOrigins]=@CorsOrigins,
					[Claims]=@Claims")
        {
        }
    }
}