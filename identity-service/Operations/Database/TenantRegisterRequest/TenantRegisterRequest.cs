using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Identity.Operations.Database.TenantRegisterRequest
{
    public class TenantRegisterRequest : BaseModelDto, IDropDown
    {
        public int? RegisteredTenantId { get; set; }
        public int? StatusLookup { get; set; }
        public string OrganizationTitle { get; set; }
        public int OrganizationIsRegistered { get; set; }
        public string? OrganizationRegistrationNumber { get; set; }
        public string? OrganizationNationalCode { get; set; }
        public string OrganizationPhoneNumber { get; set; }
        public string OrganizationAddress { get; set; }
        public string? OrganizationIbanNumber { get; set; }
        public int OrganizationActivityType { get; set; }
        public string? OrganizationCustomActivityType { get; set; }
        public int? OrganizationTypeLookup { get; set; }
        public string? OrganizationCustomTypeLookup { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
        public string PersonPhoneNumber { get; set; }
        public string PersonNationalNumber { get; set; }
        public string? PersonEmail { get; set; }
        public int PersonRelationTypeLookup { get; set; }
        public string? PersonCustomRelationTypeLookup { get; set; }
        public bool IsActive { get; set; }
       public string Title {get; set;}
    }
}
