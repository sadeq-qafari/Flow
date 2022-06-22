using System.Linq;
using System.Threading.Tasks;
using Identity.Operations.Database.User.Dtos;
using Meteor.Operation.Db;
using Meteor.Utils;

namespace Identity.Operations.Database.User.Commands
{
    public class UserUpdate : DbOperationAsync<UserUpdateInDto, bool>
    {
        protected override Task<UserUpdateInDto> PrepareInputAsync()
        {
            Input.Password = string.IsNullOrEmpty(Input.Password?.Trim())
                ? null
                : PasswordHash.Hash(Input.Password);
            return Task.FromResult(Input);
        }

        protected override async Task ValidateInputAsync()
        {
            var hasAccess = (await NewSql(sql => sql
                .Select("[Identity].[TenantUser]", "1")
                .Where("UserId=@Id AND TenantId=@TenantId AND IsDeleted=0")).QueryAsync<int>()).Any();
            if (!hasAccess)
	            throw Errors.AccessDenied("access_denied_for_current_tenant");
        }

        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(sql => sql.Update("[Identity].[User]",
                        $@"[UserName]=@UserName,
									[NormalizedUserName]=LOWER(@UserName),
									[FirstName]=@FirstName,
									[LastName]=@LastName,
									[Email]=@Email,
									[NormalizedEmail]=LOWER(@Email),
									[EmailConfirmed]=@EmailConfirmed,
									[NationalCode]=@NationalCode,
									[PasswordHash]=IIF(LEN(TRIM(@Password))>5,@Password,PasswordHash),
									[PhoneNumber]=@UserName,
									[PhoneNumberConfirmed]=@PhoneNumberConfirmed,
									[TwoFactorEnabled]=@TwoFactorEnabled,
									[LockoutEnd]=@LockoutEnd,
									[LockoutEnabled]=@LockoutEnabled,
									[ModifiedBy]=@ModifiedBy,
									[ModifiedAt]=GETDATE()")
                    .Where("[User].Id = @Id")
                ).ExecuteAsync()
                .ValidateDatabaseAffectedRows("user_update_failed") > 0;
        }
    }
}
