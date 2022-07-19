namespace Flow.Operations.FormProperty.Dtos
{
    public class FormPropertyDto : FormProperty
    {
        public string? FormTitle { get; set; }
        public string? ElementTitle { get; set; }
        public string? IsHiddenInGridTitle { get; set; }
        public string? RelatedFormTitle { get; set; }
        public string? RelatedFormPropertyTitle { get; set; }
        public string? LookupTitle { get; set; }
    }
}
