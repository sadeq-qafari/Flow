using Core.Meteor;

namespace Identity.Operations.Database.TenantRegisterRequest.Queries
{
    public class GetTenantRegisterRequestAsDropDown : DbQueryAsDropDown<TenantRegisterRequest>
    {
        public GetTenantRegisterRequestAsDropDown() : base("[Identity].[TenantRegisterRequest]")
        {
        }
    }
}
