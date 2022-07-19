using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Meteor.Models;
using Dapper;
using Meteor.Database;
using Meteor.Utils;
using NodaTime;

namespace Core.Meteor
{
    public static class SqServices
    {
        public static long LatestVersion;
        public static List<Service> Services { get; private set; } = new List<Service>();

        public static async Task Reload(LazyDbConnection lazyDbConnection, string apiGatewayUrl)
        {
            const string sqlText = @"
SELECT Service.*, Core.ServiceConfig.Value AS BaseUrl FROM Core.Service
    INNER JOIN Core.ServiceConfig ON ServiceName = Name AND [Key] = N'base_url'
WHERE IsDeleted=0;

SELECT * FROM Core.Model WHERE IsDeleted=0;

SELECT * FROM Core.ModelProperty WHERE IsDeleted=0 ORDER BY [Index];

SELECT * FROM Core.ModelPropertyDatagrid WHERE IsDeleted=0;

SELECT * FROM Core.ModelPropertyElement WHERE IsDeleted=0;

SELECT * FROM Core.ModelPropertyLookup WHERE IsDeleted=0;

SELECT * FROM Core.ModelFilter WHERE IsDeleted=0 AND IsActive=1;
";
            var db = await lazyDbConnection.GetConnectionAsync();
            var grid = await db.QueryMultipleAsync(sqlText);
            var services = await grid.ReadAsync<Service>().ToListAsync();
            var models = await grid.ReadAsync<Model>().ToListAsync();
            var modelProperties = await grid.ReadAsync<ModelProperty>().ToListAsync();
            var modelPropertyDataGrids = await grid.ReadAsync<ModelPropertyDataGrid>().ToListAsync();
            var modelPropertyElements = await grid.ReadAsync<ModelPropertyElement>().ToListAsync();
            var modelPropertyLookups = await grid.ReadAsync<ModelPropertyLookup>().ToListAsync();
            var modelFilters = await grid.ReadAsync<ModelFilter>().ToListAsync();

            foreach (var item in modelPropertyDataGrids)
            foreach (var property in modelProperties.Where(x => x.ModelPropertyDataGridId == item.Id))
                property.DataGrid = item;

            foreach (var item in modelPropertyElements)
            foreach (var property in modelProperties.Where(x => x.ModelPropertyElementId == item.Id))
                property.Element = item;

            var lookupsByPropertyId = modelPropertyLookups.GroupBy(x => x.ModelPropertyId)
                .ToDictionary(x => x.Key);

            var propertiesToAppend = modelProperties
                .Where(x => !string.IsNullOrWhiteSpace(x.LabelFieldName))
                .Select(x => new ModelProperty
                {
                    Id = 0,
                    ModelId = x.ModelId,
                    Index = x.Index,
                    Name = x.LabelFieldName!,
                    Title = x.Title,
                    Type = "string",
                    Visible = true,
                    Filterable = true,
                    IsLtr = x.IsLtr
                })
                .ToList();
            modelProperties.AddRange(propertiesToAppend);

            foreach (var property in modelProperties)
            {
                if (property.RelatedModelId.HasValue)
                {
                    var relatedModel = models.FirstOrDefault(x => x.Id == property.RelatedModelId);
                    if (relatedModel == null) continue;

                    var relatedService = services.FirstOrDefault(x => x.Id == relatedModel.ServiceId);
                    if (relatedService == null) continue;

                    property.RelatedModelUrl =
                        $"{apiGatewayUrl}/{relatedService.Name}/{relatedModel.Name}";
                }

                if (lookupsByPropertyId.ContainsKey(property.Id))
                    property.LookupOptions = lookupsByPropertyId[property.Id].ToList();

                var model = models.FirstOrDefault(x => x.Id == property.ModelId);
                model?.Properties.Add(property);


                if (property.RelatedModelId.HasValue)
                {
                    var destModel = models.FirstOrDefault(x => x.Id == property.RelatedModelId.Value);
                    if (destModel != null)
                    {
                        var service = services.FirstOrDefault(x => x.Id == model.ServiceId);
                        if (service != null)
                            destModel.RelatedModels.Add(new RelatedModel
                            {
                                ServiceName = service.Name,
                                Name = model.Name,
                                Title = model.Title,
                                PropertyName = property.Name,
                                PropertyTitle = property.Title
                            });
                    }
                }
            }

            foreach (var filter in modelFilters)
            {
                var model = models.FirstOrDefault(x => x.Id == filter.ModelId);
                model?.Filters.Add(filter);
            }

            foreach (var service in services)
                service.Models = models.Where(x => x.ServiceId == service.Id).ToList();

            Services = services;
            LatestVersion = SystemClock.Instance.GetCurrentInstant().ToUnixTimeSeconds();
        }

        public static IEnumerable<Service> GetServices(IEnumerable<string>? names) =>
            Services.Where(x => names?.Any(name =>
                string.Equals(x.Name, name, StringComparison.InvariantCultureIgnoreCase)) ?? false);

        public static Service? GetService(string? name) =>
            Services.FirstOrDefault(x => string.Equals(x.Name, name, StringComparison.InvariantCultureIgnoreCase));

        public static Service? GetService(int? serviceId) =>
            Services.FirstOrDefault(x => x.Id == serviceId);


        public static Model? GetModel(string? serviceName, string? modelName) =>
            GetService(serviceName)?.Models
                .FirstOrDefault(x => string.Equals(x.Name, modelName, StringComparison.InvariantCultureIgnoreCase));

        public static Model? GetModel(int? modelId) =>
            Services.FirstOrDefault(s => s.Models.Any(m => m.Id == modelId))?.Models.First(m => m.Id == modelId);

        public static ModelProperty? GetModelProperty(string? serviceName, string? modelName, string? propertyName) =>
            GetModel(serviceName, modelName)?.Properties.FirstOrDefault(x =>
                string.Equals(x.Name, propertyName, StringComparison.InvariantCultureIgnoreCase));
    }
}
