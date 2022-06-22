using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantRegisterRequest.Queries
{
    public class GetTenantRegisterRequestAsDropDown : SaanaaDbQueryAsDropDown<TenantRegisterRequest>
    {
        public GetTenantRegisterRequestAsDropDown() : base("[Identity].[TenantRegisterRequest]")
        {
        }
    }
}
