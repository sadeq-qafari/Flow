namespace Core.Meteor.Models
{
    public class ModelFilter
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ModelId { get; set; }
        public string FilterString { get; set; }
        public int TypeLookup { get; set; }
    }
}
