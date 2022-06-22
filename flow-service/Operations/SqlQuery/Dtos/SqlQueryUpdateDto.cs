using Saanaa.Core.Meteor.Dto;

namespace Flow.Operations.SqlQuery.Dtos
{
    public class SqlQueryUpdateInDto : SaanaaDbUpdateInDto
    {
        public string Title { get; set; }
        public string Query { get; set; }
        public string? ResultType { get; set; }

    }
}
