using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Identity.Operations.Database.User.Dtos;
using Meteor.Operation.Db;
using Meteor.Utils;
using Core.Meteor;

namespace Identity.Operations.Database.User.Commands
{
    public class RegisterUser : DbOperationAsync<UserRegisterInDto, long>, INeedLog,IHaveTableName
    {
        public string TableName { get; set; } = "[Identity].[User]";
        protected override Task ValidateInputAsync()
        {
            var mobileRegex = new Regex("^\\d{11}$");
            Input.Username = Input.Username.Trim().TrimStart('0').PadLeft(11, '0');
            if (!mobileRegex.IsMatch(Input.Username))
                throw Errors.InvalidInput("mobile");

            return Task.CompletedTask;
        }

        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(@"EXECUTE [Identity].sp_UserRegister @UserName = @UserName
                                  ,@FirstName = @FirstName
                                  ,@LastName = @LastName
                                  ,@Email = @Email
                                  ,@EmailConfirmed = @EmailConfirmed
                                  ,@NationalNumber = @NationalNumber
                                  ,@PasswordHash = @PasswordHash
                                  ,@PhoneNumber = @PhoneNumber
                                  ,@PhoneNumberConfirmed = @PhoneNumberConfirmed
                                  ,@TwoFactorEnabled = @TwoFactorEnabled
                                  ,@CreatedBy = @CreatedBy
                                  ,@BranchId = @BranchId
                                  ,@TenantId = @TenantId",new
            {
                CreatedBy = Input.CreatedBy,
                BranchId = Input.BranchId,
                TenantId = Input.TenantId,
                UserName = Input.Username,
                FirstName = Input.FirstName,
                LastName = Input.LastName,
                Email = Input.Email,
                EmailConfirmed = false,
                NationalNumber = Input.NationalCode,
                PasswordHash = PasswordHash.Hash(Input.Password),
                PhoneNumber = Input.Username,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false
            }).ExecuteScalarAsync<long>();
        }

    }
}
