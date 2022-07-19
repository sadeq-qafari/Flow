using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Humanizer;
using Identity.Operations.Database.TenantRegisterRequest.Dtos;
using Meteor.Utils;
using Core.AspNetCore.Operations.Logic.SendMessage;
using Core.AspNetCore.Operations.Logic.SendMessage.Dto;
using Core.Meteor;

namespace Identity.Operations.Database.TenantRegisterRequest.Commands
{
    public class TenantRegisterRequestAdd : DbInsertAsync<TenantRegisterRequestAddInDto>
    {
        public TenantRegisterRequestAdd() : base("[Identity].[TenantRegisterRequest]",
            @"[StatusLookup],
						[OrganizationTitle],
						[OrganizationIsRegistered],
						[OrganizationRegistrationNumber],
						[OrganizationNationalCode],
						[OrganizationPhoneNumber],
						[OrganizationAddress],
						[OrganizationIbanNumber],
						[OrganizationActivityType],
						[OrganizationCustomActivityType],
						[OrganizationTypeLookup],
						[OrganizationCustomTypeLookup],
						[PersonFirstName],
						[PersonLastName],
						[PersonPhoneNumber],
						[PersonNationalNumber],
						[PersonEmail],
						[PersonRelationTypeLookup],
						[PersonCustomRelationTypeLookup]",
            @"@StatusLookup,
						@OrganizationTitle,
						@OrganizationIsRegistered,
						@OrganizationRegistrationNumber,
						@OrganizationNationalCode,
						@OrganizationPhoneNumber,
						@OrganizationAddress,
						@OrganizationIbanNumber,
						@OrganizationActivityType,
						@OrganizationCustomActivityType,
						@OrganizationTypeLookup,
						@OrganizationCustomTypeLookup,
						@PersonFirstName,
						@PersonLastName,
						@PersonPhoneNumber,
						@PersonNationalNumber,
						@PersonEmail,
						@PersonRelationTypeLookup,
						@PersonCustomRelationTypeLookup")
        {
        }

        protected override async Task OnSuccessAsync()
        {
            try
            {
                var apiClient = OperationFactory!.GetService<ApiClient>()
                                ?? throw Errors.InternalError("api_client_not_registered");
                var msgId = await OperationFactory!.New<SendMessage>().ExecuteAsync(
                    new SendMessageInDto
                    {
                        MessageName = "TenantRegisterReport",
                        Receivers = Input.PersonPhoneNumber,
                        TenantId = Input.TenantId,
                        Params = new List<string>()
                        {
                            Input.OrganizationTitle.Underscore(),
                            $"{Input.PersonFirstName} {Input.PersonLastName}".Underscore(),
                            Input.PersonPhoneNumber,
                            "حامیانه",
                        }
                    });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
