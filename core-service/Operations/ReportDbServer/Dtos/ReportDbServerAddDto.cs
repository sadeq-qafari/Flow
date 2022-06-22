using Saanaa.Core.Meteor.Dto;

namespace Core.Operations.ReportDbServer.Dtos
{
    public class ReportDbServerAddInDto : SaanaaDbInsertInDto
    {
        public string Title { get; set; }
        public string ConnectionString { get; set; }
        public int EngineTypeLookup { get; set; }

    }
}
