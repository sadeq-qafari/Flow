namespace Identity.Operations.Database.TenantRegisterRequest.Dtos
{
    public class TenantRegisterRequestDto : TenantRegisterRequest
    {
        public string? StatusLookupTitle { get; set; }
        public string? OrganizationActivityTypeTitle { get; set; }
        public string? OrganizationTypeLookupTitle { get; set; }
        public string? OrganizationCustomTypeLookupTitle { get; set; }
        public string? PersonRelationTypeLookupTitle { get; set; }
        public string? PersonCustomRelationTypeLookupTitle { get; set; }
    }
}
