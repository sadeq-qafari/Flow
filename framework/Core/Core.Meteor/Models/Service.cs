using System.Collections.Generic;

namespace Core.Meteor.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string BaseUrl { get; set; }

        public List<Model> Models { get; set; } = new List<Model>();
    }
}
