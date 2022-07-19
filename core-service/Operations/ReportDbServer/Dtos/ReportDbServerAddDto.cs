using Core.Meteor.Dto;

namespace Core.Operations.ReportDbServer.Dtos
{
    public class ReportDbServerAddInDto : DbInsertInDto
    {
        public string Title { get; set; }
        public string ConnectionString { get; set; }
        public int EngineTypeLookup { get; set; }

    }
}
