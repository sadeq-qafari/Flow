using System.Collections.Generic;

namespace Flow.Operations.Form.Dtos
{
    public class ImportExcelDto
    {
        public string Reference { get; set; }
        public Dictionary<string, List<Dictionary<string, string?>>> Forms { get; set; }
    }
}
