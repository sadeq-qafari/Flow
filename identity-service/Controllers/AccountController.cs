using System.Threading.Tasks;
using Identity.Helper;
using Identity.Operations.Database.User.Commands;
using Identity.Operations.Database.User.Dtos;
using Identity.Operations.Database.User.Queries;
using Identity.Operations.Logic;
using Identity.Operations.Logic.CacheUserRegisterInfo;
using Identity.Operations.Logic.Dto;
using Identity.Operations.Logic.GenerateToken;
using Identity.Operations.Logic.GenerateToken.Dto;
using Identity.Operations.Logic.GenerateTokenHash;
using Identity.Operations.Logic.RegisterUserFromCache;
using Identity.Operations.Logic.SendVerificationCode;
using Identity.Operations.Logic.ValidateVerificationCode.Dto;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saanaa.Core.AspNetCore.Security;
using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Identity.Controllers
{
    [SecurityHeaders]
    [OperationResult]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly OperationFactory _operationFactory;
        private readonly IAuthorizationService _authorizationService;

        public AccountController(OperationFactory operationFactory, IAuthorizationService authorizationService)
        {
            _operationFactory = operationFactory;
            _authorizationService = authorizationService;
        }

        [HttpPost("token")]
        public Task<GenerateTokenOutDto?> GenerateToken([FromBody] GenerateTokenInDto m) =>
            _operationFactory.New<GenerateToken>().ExecuteAsync(m);

        [Authorize]
        [HttpPost("GenerateHash")]
        public async Task<string?> GenerateHash([FromBody] UserBranchDto m)
        {
            // TODO: test for both backend and api request
            if (!(await _authorizationService.AuthorizeAsync(User, "backend")).Succeeded)
                m.UserId = HttpContext.UserInfo()!.Id;

            return await _operationFactory.New<GenerateTokenHash>().ExecuteAsync(m);
        }

        [Authorize]
        [HttpPost("userInfo")]
        public string UserInfo() =>
            HttpContext.UserInfo()!.ToJson();

        [HttpPost("check/{username}")]
        public Task<bool> Check([FromRoute] CheckUserInDto m)
        {
            m.TenantId = SaanaaTenants.GetTenant(HttpContext)!.Id;
            return _operationFactory.New<CheckUser>().ExecuteAsync(m);
        }


        [NeedPermission("Identity.User.Create")]
        [HttpPost("register/{branchId}")]
        public Task<long> RegisterByAdmin(int branchId, [FromBody] UserRegisterInDto m)
        {
            m.BranchId = branchId;
            return _operationFactory.New<RegisterUser>().ExecuteAsync(m);

            // Admin or user?
            // Verified? or needs phone verification?
            // how to do verified registration?
            // whats the password for mobile registration?

            // Add User
            // Add UserTenant
            // Add UserRole
            // Add Person and Etc
        }

        [HttpPost("register")]
        public async Task<bool> RegisterUser([FromBody] UserRegisterInDto m)
        {
            m.TenantId = SaanaaTenants.GetTenant(HttpContext)!.Id;
            return await _operationFactory.New<CacheUserRegisterInfo>().ExecuteAsync(m);
        }


        [HttpPost("register/confirm")]
        public async Task<GenerateTokenOutDto?> ConfirmUserRegistration([FromBody] ValidateVerificationCodeInDto m)
        {
            var res = await _operationFactory.New<RegisterUserFromCache>().ExecuteAsync(m);
            return res
                ? await _operationFactory.New<GenerateToken>().ExecuteAsync(new GenerateTokenInDto
                {
                    Type = TokenGrantType.VerificationCode,
                    UserType = TokenUserType.User,
                    VerificationCode = m.Code,
                    Username = m.Username
                })
                : null;
        }

        [HttpPost("sendCode/{username}")]
        public Task<bool> SendCode([FromRoute] string username)
        {
            var tenantUrl = string.IsNullOrEmpty(HttpContext?.Request.Headers["origin"].ToString())
                ? HttpContext?.Request.Headers["Saanaa-Origin"].ToString()
                : HttpContext?.Request.Headers["origin"].ToString();

            return _operationFactory.New<SendVerificationCode>().ExecuteAsync(new SendVerificationCodeInDto
            {
                MobileNumber = username,
                TenantUrl = tenantUrl
            });
        }


        [NeedPermission]
        [HttpPost("changePassword")]
        public Task<bool> ChangePassword([FromBody] UserChangePasswordInDto m) =>
            _operationFactory.New<UserChangePassword>().ExecuteAsync(m);


        [Authorize]
        [HttpGet("logout")]
        public Task<bool> Logout(SaanaaDbUpdateInDto m) =>
            _operationFactory.New<ClearUserCache>().ExecuteAsync(m);
    }
}
