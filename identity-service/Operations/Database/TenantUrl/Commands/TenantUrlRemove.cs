using Core.Meteor;

namespace Identity.Operations.Database.TenantUrl.Commands
{
    public class TenantUrlRemove : DbDeleteAsync
    {
        public TenantUrlRemove() : base("[Identity].[TenantUrl]")
        {
        }
    }
}