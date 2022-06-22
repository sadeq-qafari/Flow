using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantRegisterRequest.Queries
{
    public class GetTenantRegisterRequest : SaanaaDbSelectAsync<TenantRegisterRequest?>
    {
        public GetTenantRegisterRequest() : base("[Identity].[TenantRegisterRequest]")
        {
        }
    }
}