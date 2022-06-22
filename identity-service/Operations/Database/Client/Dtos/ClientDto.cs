namespace Identity.Operations.Database.Client.Dtos
{
    public class ClientDto : Client
    {
        public string? ClientTitle { get; set; }
        public string? IncludeJwtTitle { get; set; }
    }
}
