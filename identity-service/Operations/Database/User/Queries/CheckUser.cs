using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Identity.Operations.Database.User.Dtos;
using Meteor.Operation.Db;
using Meteor.Utils;

namespace Identity.Operations.Database.User.Queries
{
    public class CheckUser : DbOperationAsync<CheckUserInDto, bool>
    {
        protected override async Task ExecutionAsync()
        {
            var mobileRegex = new Regex("^\\d{11}$");
            var username = Input.Username.Trim().TrimStart('0').PadLeft(11, '0');
            if (!mobileRegex.IsMatch(Input.Username))
                throw Errors.InvalidInput("mobile");

            var item = await NewSql(sql => sql.Select("[Identity].[User]")
                    .InnerJoin("[Identity].[TenantUser]",
                        "[TenantUser].UserId=[User].Id AND [TenantUser].TenantId=@TenantId")
                    .Where("UserName=@Username"))
                .QueryFirstOrDefaultAsync<User?>();
            Output = item != null;
        }
    }
}
