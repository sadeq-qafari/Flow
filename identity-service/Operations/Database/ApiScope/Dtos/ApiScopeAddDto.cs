using Core.Meteor.Dto;

namespace Identity.Operations.Database.ApiScope.Dtos
{
    public class ApiScopeAddInDto : DbInsertInDto
    {
        public string Name { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public bool Required { get; set; }
        public bool Emphasize { get; set; }
        public bool ShowInDiscoveryDocument { get; set; }
        public int ApiResourceId { get; set; }
        public string? Claims { get; set; }
        public string? Properties { get; set; }

    }
}
