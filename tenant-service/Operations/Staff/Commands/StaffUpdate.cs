using Core.Meteor;
using Tenant.Operations.Staff.Dtos;

namespace Tenant.Operations.Staff.Commands
{
    public class StaffUpdate : DbUpdateAsync<StaffUpdateInDto>
    {
        public StaffUpdate() : base("[Tenant].[v_Staff]",
            @"[FirstName]=@FirstName,
					[LastName]=@LastName,
					[NationalNumber]=@NationalNumber,
					[GenderLookup]=@GenderLookup,
					[Description]=@Description")
        {
        }
    }
}