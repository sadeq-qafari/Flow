using Core.Meteor.Dto;

namespace Core.Operations.ModelPropertyDatagrid.Dto
{
    public class AddModelPropertyDatagridInDto : DbInsertInDto
    {
        public int? Index { get; set; }
        public string Name { get; set; }
        public bool Visible { get; set; }
        public bool Sortable { get; set; }
        public string? ViewType { get; set; }
        public string? Width { get; set; }
        public string? ReferenceUrl { get; set; }
        public string Alignment { get; set; }
        public string? Css { get; set; }
        public string? HeaderCss { get; set; }

    }
}
