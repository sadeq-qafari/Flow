using Saanaa.Core.Meteor;
using Tenant.Operations.Organization.Dto;

namespace Tenant.Operations.Organization.Commands
{
    public class AddOrganization : SaanaaDbInsertAsync<AddOrganizationInDto>
    {
        public AddOrganization() : base("[Tenant].[Organization]",
            @"[Id], [Title], [OfficialTitle], [Logo], [About], [CityId], [EconomicCode], [NationalNumber], [PostalCode], [Address], [PhoneNumber], [RegisterNumber], [StampImage]",
            @"@Id, @Title, @OfficialTitle, @Logo, @About, @CityId, @EconomicCode, @NationalNumber, @PostalCode, @Address, @PhoneNumber, @RegisterNumber, @StampImage")
        {
        }
    }
}
