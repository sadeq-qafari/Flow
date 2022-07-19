using System.Collections.Generic;
using Core.Meteor;
using Core.Meteor.Dto;

namespace Tenant.Operations.Report
{
    public class Report : BaseModelDto, IDropDown
    {
        public string? Title { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int TypeLookup { get; set; }
        public string ServiceName { get; set; }
        public string? PermissionName { get; set; }
        public string? Link { get; set; }
        public int Size { get; set; }
        public string Query { get; set; }
        public Dictionary<string,object>? Parameters { get; set; }
        public bool IsActive { get; set; }

    }
}
