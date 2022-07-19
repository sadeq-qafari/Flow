using Identity.Operations.Database.TenantRegisterRequest.Dtos;
using Core.Meteor;

namespace Identity.Operations.Database.TenantRegisterRequest.Commands
{
    public class TenantRegisterRequestUpdate : DbUpdateAsync<TenantRegisterRequestUpdateInDto>
    {
        public TenantRegisterRequestUpdate() : base("[Identity].[TenantRegisterRequest]",
            @"[StatusLookup]=@StatusLookup,
					[OrganizationTitle]=@OrganizationTitle,
					[OrganizationIsRegistered]=@OrganizationIsRegistered,
					[OrganizationRegistrationNumber]=@OrganizationRegistrationNumber,
					[OrganizationNationalCode]=@OrganizationNationalCode,
					[OrganizationPhoneNumber]=@OrganizationPhoneNumber,
					[OrganizationAddress]=@OrganizationAddress,
					[OrganizationIbanNumber]=@OrganizationIbanNumber,
					[OrganizationActivityType]=@OrganizationActivityType,
					[OrganizationCustomActivityType]=@OrganizationCustomActivityType,
					[OrganizationTypeLookup]=@OrganizationTypeLookup,
					[OrganizationCustomTypeLookup]=@OrganizationCustomTypeLookup,
					[PersonFirstName]=@PersonFirstName,
					[PersonLastName]=@PersonLastName,
					[PersonPhoneNumber]=@PersonPhoneNumber,
					[PersonNationalNumber]=@PersonNationalNumber,
					[PersonEmail]=@PersonEmail,
					[PersonRelationTypeLookup]=@PersonRelationTypeLookup,
					[PersonCustomRelationTypeLookup]=@PersonCustomRelationTypeLookup")
        {
        }
    }
}