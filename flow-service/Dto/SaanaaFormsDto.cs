using System.Collections.Generic;
using Flow.Core.Models;

namespace Flow.Dto
{
    public class SaanaaFormsDto
    {
        public IEnumerable<FormModel>? Forms { get; set; }
        public long Version { get; set; }
    }
}