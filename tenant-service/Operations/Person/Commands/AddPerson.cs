using Saanaa.Core.Meteor;
using Tenant.Operations.Person.Dto;

namespace Tenant.Operations.Person.Commands
{
    public class AddPerson : SaanaaDbInsertAsync<AddPersonInDto>
    {
        public AddPerson() : base("[Tenant].[Person]",
            "[FirstName], [LastName], [NationalNumber], [GenderLookup], [Description]",
            "@FirstName, @LastName, @NationalNumber, @GenderLookup, @Description")
        {
        }
    }
}

