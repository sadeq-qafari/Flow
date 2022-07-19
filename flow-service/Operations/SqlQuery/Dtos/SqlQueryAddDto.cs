using Core.Meteor.Dto;

namespace Flow.Operations.SqlQuery.Dtos
{
    public class SqlQueryAddInDto : DbInsertInDto
    {
        public string Title { get; set; }
        public string Query { get; set; }
        public string? ResultType { get; set; }

    }
}
