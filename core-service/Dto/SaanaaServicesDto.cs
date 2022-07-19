using System.Collections.Generic;

namespace Core.Dto
{
    public class ServicesDto
    {
        public IEnumerable<Core.Meteor.Models.Service>? Services { get; set; }
        public long Version { get; set; }
    }
}
