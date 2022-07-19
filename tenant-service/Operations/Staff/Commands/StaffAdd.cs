using Core.Meteor;
using Tenant.Operations.Staff.Dtos;

namespace Tenant.Operations.Staff.Commands
{
    public class StaffAdd : DbInsertAsync<StaffAddInDto>
    {
        public StaffAdd() : base("[Tenant].[v_Staff]",
            @"[FirstName],
						[LastName],
						[NationalNumber],
						[GenderLookup],
						[Description]",
            @"@FirstName,
						@LastName,
						@NationalNumber,
						@GenderLookup,
						@Description")
        {
        }
    }
}

