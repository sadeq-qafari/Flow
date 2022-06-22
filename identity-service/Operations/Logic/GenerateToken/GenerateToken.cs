using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Identity.Operations.Database.TenantUser.Queries;
using Identity.Operations.Database.User.Dtos;
using Identity.Operations.Database.User.Queries;
using Identity.Operations.Logic.GenerateToken.Dto;
using IdentityModel;
using IdentityModel.Client;
using Meteor.Operation;
using Meteor.Utils;
using Microsoft.AspNetCore.Http;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Logic.GenerateToken
{
    public class GenerateToken : OperationAsync<GenerateTokenInDto, GenerateTokenOutDto> ,INeedLog, IHaveTableName
    {
        public string TableName { get; set; } = "[Identity].[Token]";
        protected override Task<GenerateTokenInDto> PrepareInputAsync()
        {
            Input.Username = PersianText.PersianToEnglishNumber(Input.Username);
            Input.Username = PersianText.ArabicToEnglishNumber(Input.Username);
            Input.Password = PersianText.PersianToEnglishNumber(Input.Password);
            Input.Password = PersianText.ArabicToEnglishNumber(Input.Password);
            Input.VerificationCode = PersianText.PersianToEnglishNumber(Input.VerificationCode);
            Input.VerificationCode = PersianText.ArabicToEnglishNumber(Input.VerificationCode);
            return Task.FromResult(Input);
        }

        protected override async Task ExecutionAsync()
        {
            var result = await RequestToken();

            if (result == null || result.IsError)
                throw Errors.InternalError(result?.Error);

            var claims = new JwtSecurityTokenHandler().ReadJwtToken(result.AccessToken).Claims.GroupBy(x => x.Type).ToDictionary(
                x => x.Key,
                x =>
                {
                    var items = x.Select(y => y.Value)?.ToList();
                    if (items?.Count > 1)
                        return (object) items;
                    else
                        return items?.FirstOrDefault();
                });

            Output = new GenerateTokenOutDto
            {
                AccessToken = result.AccessToken,
                RefreshToken = result.RefreshToken,
                Tenants = (await New<GetAllUserTenants>().ExecuteAsync(claims.GetValueOrDefault("username", "0")?.ToString()))?
                    .Where(x => x.RoleCount > 0),
                Claims = claims,
                Permissions = await New<GetUserPermissions>().ExecuteAsync(new GetUserPermissionsInDto
                {
                    ActionBy = int.Parse(claims.GetValueOrDefault("sub", "0")?.ToString() ?? "0"),
                    TenantId = int.Parse(claims.GetValueOrDefault("tenant_id", "0")?.ToString() ?? "0"),
                    BranchId = int.Parse(claims.GetValueOrDefault("branch_id", "0")?.ToString() ?? "0")
                })
            };
        }

        private async Task<TokenResponse> RequestToken()
        {
            var (client, tokenEndpoint) = await GetIdentityServerClient();
            var originUrl = GetOriginUrl();

            if (Input.Type == TokenGrantType.Refresh)
                return await client.RequestRefreshTokenAsync(new RefreshTokenRequest()
                {
                    Address = tokenEndpoint,

                    ClientId = GetClientId(),
                    ClientSecret = "dialogflow",
                    Scope = "",

                    RefreshToken = Input.RefreshToken
                });

            return await client.RequestTokenAsync(new TokenRequest
            {
                Address = tokenEndpoint,
                ClientId = GetClientId(),
                ClientSecret = "dialogflow",
                Parameters = new Parameters()
                {
                    {"username", Input.Username},
                    {"password", Input.Password},
                    {"verification_code", Input.VerificationCode},
                    {"hash", Input.Hash},
                    {"scope", ""},
                    {"OriginUrl", originUrl}
                },
                RequestUri = new Uri(originUrl),
                GrantType = GetGrantType()
            });
        }

        private string GetClientId() =>
            Input.UserType switch
            {
                TokenUserType.User => "UserClient",
                TokenUserType.Admin => "AdminClient",
                _ => throw Errors.InvalidInput("invalid_user_type")
            };

        private string GetGrantType() =>
            Input.Type switch
            {
                TokenGrantType.VerificationCode => "verification_code",
                TokenGrantType.Hash => "hash_code",
                TokenGrantType.UsernamePassword => OidcConstants.GrantTypes.Password,
                _ => throw Errors.InvalidInput("invalid_token_type")
            };

        private string GetBaseUrl()
        {
            var request = GetHttpRequest();
            return request.Scheme + "://" + request.Host.ToUriComponent();
        }

        private string GetOriginUrl()
        {
            return string.IsNullOrEmpty(GetHttpRequest()!.Headers["origin"].ToString())
                ? GetHttpRequest()!.Headers["Saanaa-Origin"].ToString()
                : GetHttpRequest()!.Headers["origin"].ToString();
        }

        private HttpRequest GetHttpRequest() =>
            OperationFactory?.GetService<IHttpContextAccessor>()?.HttpContext?.Request
            ?? throw Errors.InternalError("http_context_accessor_is_not_registered");

        private async Task<(HttpClient, string)> GetIdentityServerClient()
        {
            var httpClientFactory = OperationFactory?.GetService<IHttpClientFactory>()
                                    ?? throw Errors.InternalError("http_client_factory_is_not_registered");
            var client = httpClientFactory.CreateClient();
            var disco = await client.GetDiscoveryDocumentAsync(GetBaseUrl());

            if (disco.IsError)
                throw Errors.InternalError("identity_server_is_not_discovered");

            return (client, disco.TokenEndpoint);
        }

    }
}
