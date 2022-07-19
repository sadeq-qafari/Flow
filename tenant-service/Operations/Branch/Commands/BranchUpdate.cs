using Core.Meteor;
using Tenant.Operations.Branch.Dtos;

namespace Tenant.Operations.Branch.Commands
{
    public class BranchUpdate : DbUpdateAsync<BranchUpdateInDto>
    {
        public BranchUpdate() : base("[Identity].[Branch]",
            @"[CityId]=@CityId,
					[Title]=@Title,
					[Phone]=@Phone,
					[Fax]=@Fax,
					[Address]=@Address,
					[GeoLocation]=@GeoLocation,
					[PostalCode]=@PostalCode")
        {
        }
    }
}
