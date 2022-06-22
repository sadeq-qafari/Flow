using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantRegisterRequest.Queries
{
    public class GetTenantRegisterRequestByIds : SaanaaDbQueryByIds<TenantRegisterRequest>
    {
        public GetTenantRegisterRequestByIds() : base("[Identity].[TenantRegisterRequest]")
        {
        }
    }
}