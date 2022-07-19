using System.Collections.Generic;

namespace Flow.Operations.Form.Dtos
{
    public class SubmitFormDto
    {
        public int Id { get; set; }
        public IEnumerable<object>? SimilarData { get; set; }
    }
}
