namespace Tenant.Operations.Organization.Dto
{
    public class OrganizationIncompleteInformationDto
    {
        public int ModelId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceTitle { get; set; }
        public string ModelName { get; set; }
        public string ModelTitle { get; set; }
        public bool IsDone { get; set; }
    }
}