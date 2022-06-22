using System.Collections.Generic;

namespace Core.Operations.Menu.Dto
{
    public class GetMenuByUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public int Index { get; set; }
        public string? Link { get; set; }
        public string? PermissionName { get; set; }
        public string? Icon { get; set; }
        public string ColorHex { get; set; }
        public bool IsActive { get; set; }
        public List<GetMenuByUserDto> Children { get; set; } = new ();
    }
}
