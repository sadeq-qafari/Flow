using Core.Meteor;
using Tenant.Operations.Person.Dto;

namespace Tenant.Operations.Person.Commands
{
    public class UpdatePerson : DbUpdateAsync<UpdatePersonInDto>
    {
        public UpdatePerson() : base("[Tenant].[Person]",
            "[FirstName]=@FirstName, [LastName]=@LastName, [NationalNumber]=@NationalNumber, [GenderLookup]=@GenderLookup, [Description]=@Description")
        {
        }
    }
}