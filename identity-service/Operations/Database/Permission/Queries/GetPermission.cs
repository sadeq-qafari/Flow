using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Permission.Queries
{
    public class GetPermission : SaanaaDbSelectAsync<Permission?>
    {
        public GetPermission() : base("[Identity].[Permission]")
        {
        }
    }
}
