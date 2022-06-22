using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Flow.Operations.SqlQuery
{
    public class SqlQuery : BaseModelDto, IDropDown
    {
        public string Title { get; set; }
        public string Query { get; set; }
        public string? ResultType { get; set; }
        public bool IsActive { get; set; }

    }
}
