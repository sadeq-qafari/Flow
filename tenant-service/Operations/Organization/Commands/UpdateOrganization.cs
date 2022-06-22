using Saanaa.Core.Meteor;
using Tenant.Operations.Organization.Dto;

namespace Tenant.Operations.Organization.Commands
{
    public class UpdateOrganization : SaanaaDbUpdateAsync<UpdateOrganizationInDto>
    {
        public UpdateOrganization() : base("[Tenant].[Organization]",
            @"[Id]=@Id, [Title]=@Title, [OfficialTitle]=@OfficialTitle, [Logo]=@Logo, [About]=@About,
                     [CityId]=@CityId, [EconomicCode]=@EconomicCode, [NationalNumber]=@NationalNumber, 
                     [PostalCode]=@PostalCode, [Address]=@Address,[PhoneNumber]=@PhoneNumber, [RegisterNumber]=@RegisterNumber, [StampImage]=@StampImage")
        {
        }
    }
}
