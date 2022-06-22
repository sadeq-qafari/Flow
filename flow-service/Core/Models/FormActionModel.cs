namespace Flow.Core.Models
{
    public class FormActionModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? ColorHex { get; set; }
        public int FormId { get; set; }
        public int TypeLookup { get; set; }
        public string? Script { get; set; }
        public bool IsActive { get; set; }
    }
}