using Core.Meteor;
using Core.Meteor.Dto;

namespace Core.Operations.ReportDbServer
{
    public class ReportDbServer : BaseModelDto, IDropDown
    {
        public string Title { get; set; }
        public string ConnectionString { get; set; }
        public int EngineTypeLookup { get; set; }

    }
}
