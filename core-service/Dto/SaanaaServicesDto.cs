using System.Collections.Generic;

namespace Core.Dto
{
    public class SaanaaServicesDto
    {
        public IEnumerable<Saanaa.Core.Meteor.Models.Service>? Services { get; set; }
        public long Version { get; set; }
    }
}
