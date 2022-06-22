using System.Collections.Generic;
using Saanaa.Core.Meteor.Dto;

namespace Tenant.Operations.Organization.Dto
{
    public class OrganizationInfoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string OfficialTitle { get; set; }
        public string Name { get; set; }
        public ImageInfoJson Logo { get; set; }
        public int ApplicationId { get; set; }
        public string ApplicationTitle { get; set; }
        public string ApplicationName { get; set; }
        public string About { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EconomicCode {get;set;}
        public string? NationalNumber {get;set;}
        public string? PostalCode {get;set;}
        public string? RegisterNumber {get;set;}
        public ImageInfoJson? StampImage {get;set;}
        public int? CityId {get;set;}
        public string? CityTitle {get;set;}
        public Dictionary<string, object?>? Details { get; set; }
    }

    public class OrganizationDetailItem
    {
        public string Name { get; set; }
        public object? Value { get; set; }
    }
}
