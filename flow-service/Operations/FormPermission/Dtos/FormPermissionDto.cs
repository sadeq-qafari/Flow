namespace Flow.Operations.FormPermission.Dtos
{
    public class FormPermissionDto : FormPermission
    {
        public string? RoleTitle { get; set; }
        public string? FormTitle { get; set; }
        public string? PermissionTypeLookupTitle { get; set; }
        public string? FormActionTitle { get; set; }
    }
}
