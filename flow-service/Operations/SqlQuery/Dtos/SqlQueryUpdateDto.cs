using Core.Meteor.Dto;

namespace Flow.Operations.SqlQuery.Dtos
{
    public class SqlQueryUpdateInDto : DbUpdateInDto
    {
        public string Title { get; set; }
        public string Query { get; set; }
        public string? ResultType { get; set; }

    }
}
