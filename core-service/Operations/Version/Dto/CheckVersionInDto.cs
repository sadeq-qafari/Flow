namespace Core.Operations.Version.Dto
{
    public class CheckVersionInDto
    {
        public AppType AppType { get; set; }
        public string Version { get; set; }
        public int TenantId { get; set; }
    }
}
