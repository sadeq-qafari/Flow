using Core.Meteor;

namespace Identity.Operations.Database.TenantRegisterRequest.Queries
{
    public class GetTenantRegisterRequest : DbSelectAsync<TenantRegisterRequest?>
    {
        public GetTenantRegisterRequest() : base("[Identity].[TenantRegisterRequest]")
        {
        }
    }
}