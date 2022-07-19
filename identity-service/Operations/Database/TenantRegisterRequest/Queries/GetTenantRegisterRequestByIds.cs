using Core.Meteor;

namespace Identity.Operations.Database.TenantRegisterRequest.Queries
{
    public class GetTenantRegisterRequestByIds : DbQueryByIds<TenantRegisterRequest>
    {
        public GetTenantRegisterRequestByIds() : base("[Identity].[TenantRegisterRequest]")
        {
        }
    }
}