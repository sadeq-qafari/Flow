using Core.Meteor;

namespace Identity.Operations.Database.Permission.Queries
{
    public class GetPermission : DbSelectAsync<Permission?>
    {
        public GetPermission() : base("[Identity].[Permission]")
        {
        }
    }
}
