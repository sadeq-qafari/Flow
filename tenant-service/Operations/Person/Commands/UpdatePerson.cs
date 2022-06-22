using Saanaa.Core.Meteor;
using Tenant.Operations.Person.Dto;

namespace Tenant.Operations.Person.Commands
{
    public class UpdatePerson : SaanaaDbUpdateAsync<UpdatePersonInDto>
    {
        public UpdatePerson() : base("[Tenant].[Person]",
            "[FirstName]=@FirstName, [LastName]=@LastName, [NationalNumber]=@NationalNumber, [GenderLookup]=@GenderLookup, [Description]=@Description")
        {
        }
    }
}