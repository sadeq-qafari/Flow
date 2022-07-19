using System.Threading.Tasks;
using Core.AspNetCore.Operations.Db.Identity.Dto;
using Meteor.Operation.Db;
using Meteor.Utils;

namespace Identity.Operations.Database.Permission.Queries
{
    public class GetPermissions : DbOutOperationAsync<PermissionStore>
    {
        protected override async Task ExecutionAsync()
        {
            var items = await NewSql(sql => sql
                    .Select("[Identity].[Permission] Permission", "Name")
                    .Where("Permission.IsDeleted=0"))
                .QueryAsync<string>()
                .ToListAsync();
            if (items == null)
                throw Errors.DatabaseError("no_permissions");

            Output = new PermissionStore(items);
        }
    }
}
