using System.Collections.Generic;

namespace Core.Meteor.Dto
{
    public class DropDownDto<T>
    {
        public Dictionary<string, object?> Label { get; set; }
        public T Value { get; set; }
    }
}
