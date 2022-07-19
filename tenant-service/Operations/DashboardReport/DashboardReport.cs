using System.Collections.Generic;
using Core.Meteor;
using Core.Meteor.Dto;

namespace Tenant.Operations.DashboardReport
{
    public class DashboardReport : BaseModelDto, IDropDown
    {
        public int ReportId { get; set; }
        public int Index { get; set; }
        public Dictionary<string, object>? Parameters { get; set; }
        public bool IsActive { get; set; }
        public string Title { get; set; }
    }
}
