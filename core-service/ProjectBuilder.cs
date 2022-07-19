using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Meteor;
using Core.Meteor.Models;
using Humanizer;
using Meteor.Utils;

namespace Core
{
    public class ProjectBuilder
    {
        private readonly Service _service;
        private readonly string _outputDirectory;
        private readonly string _serviceName;

        public ProjectBuilder(string serviceName, string outputDirectory)
        {
            _service = SqServices.GetService(serviceName) ?? throw Errors.NotFound($"service_name={serviceName}");
            _serviceName = _service.Name.Pascalize();
            _outputDirectory = outputDirectory;
        }

        public async Task Build()
        {
            var projectRoot = Path.Combine(_outputDirectory, _service.Name.MakeFirstLetterUpper()!);
            Directory.CreateDirectory(projectRoot);
            await GenerateProjectFiles(projectRoot);
            GenerateDatabaseFiles(projectRoot);
        }

        private void GenerateDatabaseFiles(string projectRoot)
        {
            File.WriteAllLines(Path.Combine(projectRoot, "Database.sql"), new[]
            {
                CreateSchemaScript(),
                Environment.NewLine,
                CreateTables()
            });
        }

        private string CreateTables()
        {
            var sb = new StringBuilder();
            foreach (var model in _service.Models)
                sb.Append(CreateTable(model)).AppendLine().AppendLine();

            return sb.ToString();
        }


        private string CreateTable(Model model)
        {
            return $@" 
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[{_serviceName}].[{model.Name.Pascalize()}]') AND type in (N'U'))

BEGIN
CREATE TABLE [{_serviceName}].[{model.Name.Pascalize()}](
    Id INT NOT NULL IDENTITY
{string.Join("," + Environment.NewLine, model.Properties.Where(x => x.Name.ToLowerInvariant() != "id").Select(x => "    " + CreateDatabaseFieldDefinition(x)))},
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    TenantId INT NULL,
    ModifiedBy INT NULL,
    ModifiedAt DATETIME2 NULL,
    CreatedBy INT NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE()
) 
END";
        }

        private static string CreateDatabaseFieldDefinition(ModelProperty property) =>
            $"{property.Name.Pascalize()} {GetSqlType(property.Type)} {(property.IsRequired ? "NOT NULL" : "NULL")} {(property.DefaultValue != null ? $"DEFAULT {property.DefaultValue}" : "")}"
                .Trim();

        private static string GetSqlType(string type) =>
            type switch
            {
                "byte" => "TINYINT",
                "short" => "SMALLINT",
                "int" => "INT",
                "long" => "BIGINT",
                "float" => "FLOAT",
                "double" => "DOUBLE",
                "decimal" => "DECIMAL",
                "money" => "DECIMAL(17, 2)",
                "string" => "NVARCHAR(MAX)",
                "image" => "NVARCHAR(MAX)",
                "json" => "NVARCHAR(MAX)",
                "date" => "DATE",
                "time" => "TIME",
                "datetime" => "DATETIME2",

                _ => type
            };

        private string CreateSchemaScript()
        {
            return $@"IF NOT EXISTS ( SELECT  *
                FROM    sys.schemas
                WHERE   name = N'{_serviceName}' )
                EXEC('CREATE SCHEMA [{_serviceName}]');
                GO";
        }

        private async Task GenerateProjectFiles(string projectRoot)
        {
            CreateProjectFile(projectRoot);
            CreateProgramFile(projectRoot);
            CreateStartupFile(projectRoot);
            CreateAppSettings(projectRoot);
            CreateProperties(projectRoot);
            await CreateOperations(projectRoot);
            CreateControllers(projectRoot);
        }

        private void CreateControllers(string projectRoot)
        {
            var controllersDir = Path.Combine(projectRoot, "Controllers");
            Directory.CreateDirectory(controllersDir);
            foreach (var model in _service.Models)
                CreateControllerFile(model, controllersDir);
        }

        private void CreateControllerFile(Model model, string dir)
        {
            var modelName = model.Name.Pascalize();
            File.WriteAllText(Path.Combine(dir, $"{modelName}Controller.cs"), $@"using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.AspCore.Filters;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Mvc;
using {_serviceName}.Operations.{modelName};
using {_serviceName}.Operations.{modelName}.Commands;
using {_serviceName}.Operations.{modelName}.Queries;
using {_serviceName}.Operations.{modelName}.Dto;
using .Core.Meteor.Dto;
using .Core.AspNetCore.Security;

namespace {_serviceName}.Controllers
{{
    [ApiController]
    [OperationResult]
    [Route(""[controller]"")]
    public class {modelName}Controller : ControllerBase
    {{

        private readonly OperationFactory _operationFactory;
        public {modelName}Controller(OperationFactory operationFactory)
        {{
            _operationFactory = operationFactory;
        }}

        [NeedPermission(""{_serviceName.Pascalize()}.{modelName.Pascalize()}.Read"")]
        [HttpGet]
        public Task<QueryPage<{modelName}Dto>?> Get([FromQuery] DbQueryPageInDto m) => 
            _operationFactory.New<Get{modelName}Page>().ExecuteAsync(m);

        [NeedPermission]
        [HttpGet(""dropdown"")]
        public Task<IEnumerable<DropDownDto<object>>?> GetAsDropDown([FromQuery] DbQueryAsDropDownInDto m) => 
            _operationFactory.New<Get{modelName}AsDropDown>().ExecuteAsync(m);

        [NeedPermission(""{_serviceName.Pascalize()}.{modelName.Pascalize()}.Read"")]
        [HttpGet(""ids"")]
        public Task<IEnumerable<{modelName}>?> GetByIds([FromQuery] DbQueryByIdsInDto m) => 
            _operationFactory.New<Get{modelName}ByIds>().ExecuteAsync(m);

        [NeedPermission(""{_serviceName.Pascalize()}.{modelName.Pascalize()}.Read"")]
        [HttpGet(""excel"")]
        public async Task<IActionResult> GetAsExcel([FromQuery] DbQueryPageInDto m) =>
            File(await _operationFactory.New<Get{modelName}Excel>().ExecuteAsync(m),
                ""application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"", ""{modelName.Pascalize()}.xlsx"");
        

        [NeedPermission(""{_serviceName.Pascalize()}.{modelName.Pascalize()}.Read"")]
        [HttpGet(""{{id}}"")]
        public Task<{modelName}?> GetOne([FromRoute] DbSelectInDto m) =>
            _operationFactory.New<Get{modelName}>().ExecuteAsync(m);

        [NeedPermission(""{_serviceName.Pascalize()}.{modelName.Pascalize()}.Create"")]
        [HttpPost]
        public Task<long> Add({modelName}AddInDto m) =>
            _operationFactory.New<{modelName}Add>().ExecuteAsync(m);

        [NeedPermission(""{_serviceName.Pascalize()}.{modelName.Pascalize()}.Update"")]
        [HttpPut]
        public Task<bool> Update({modelName}UpdateInDto m) =>
            _operationFactory.New<{modelName}Update>().ExecuteAsync(m);

        [NeedPermission(""{_serviceName.Pascalize()}.{modelName.Pascalize()}.Delete"")]
        [HttpDelete(""{{id}}"")]
        public Task<bool> Delete([FromRoute] DbDeleteInDto m) =>
            _operationFactory.New<{modelName}Remove>().ExecuteAsync(m);
    }}
}}");
        }


        private async Task CreateOperations(string projectRoot)
        {
            var operationsDir = Path.Combine(projectRoot, "Operations");
            foreach (var model in _service.Models.Where(p=> p.IsReport == false))
                await CreateModel(operationsDir, model);
        }

        private async Task CreateModel(string operationsDir, Model model)
        {
            var modelName = model.Name.Pascalize();
            var modelDir = Path.Combine(operationsDir, modelName);
            var commandsDir = Path.Combine(modelDir, "Commands");
            var queriesDir = Path.Combine(modelDir, "Queries");
            var dtoDir = Path.Combine(modelDir, "Dtos");
            var modelFileName = Path.Combine(modelDir, $"{modelName}.cs");
            var dtoFileName = Path.Combine(dtoDir, $"{modelName}Dto.cs");
            var addDtoFileName = Path.Combine(dtoDir, $"{modelName}AddDto.cs");
            var updateDtoFileName = Path.Combine(dtoDir, $"{modelName}UpdateDto.cs");
            Directory.CreateDirectory(commandsDir);
            Directory.CreateDirectory(queriesDir);
            Directory.CreateDirectory(dtoDir);
            CreateAddCommand(model, commandsDir, modelName);
            CreateUpdateCommand(model, commandsDir, modelName);
            CreateDeleteCommand(model, commandsDir, modelName);
            CreateGetQuery(model, queriesDir, modelName);
            await CreateGetQueryPage(model, queriesDir, modelName);
            CreateGetByIdsQuery(model, queriesDir, modelName);
            CreateGetExcelQuery(model, queriesDir, modelName);
            CreateGetAsDropDownQuery(model, queriesDir, modelName);
            CreateModelFile(model, modelFileName, modelName);
            await CreateDtoFile(model, dtoFileName, modelName);
            await CreateAddDtoFile(model, addDtoFileName, modelName);
            await CreateUpdateDtoFile(model, updateDtoFileName, modelName);
        }


        private void CreateGetAsDropDownQuery(Model model, string dir, string modelName)
        {
            File.WriteAllText(Path.Combine(dir, $"Get{modelName}AsDropDown.cs"), $@"using .Core.Meteor;

namespace {_serviceName}.Operations.{modelName}.Queries
{{
    public class Get{modelName}AsDropDown : DbQueryAsDropDown<{modelName}>
    {{
        public Get{modelName}AsDropDown() : base(""[{_serviceName}].[{modelName}]"")
        {{
        }}
    }}
}}
");
        }

        private void CreateGetExcelQuery(Model model, string dir, string modelName)
        {
            var props = model.Properties.ToList();
            File.WriteAllText(Path.Combine(dir, $"Get{modelName}Excel.cs"), $@"using .Core.Meteor;
using System.Collections.Generic;
using System.Threading.Tasks;
using .{_serviceName}.Operations.{modelName}.Dtos;

namespace .{_serviceName}.Operations.{modelName}.Queries
{{
    public class Get{modelName}Excel : DbQueryExcel<{modelName}Dto>
    {{
        public Get{modelName}Excel() : base(""[{_serviceName}].[{modelName}]"")
        {{
        }}
        
        protected override async Task<List<{modelName}Dto>?> GetItems() =>
            (await OperationFactory!.New<Get{modelName}Page>().ExecuteAsync(Input))?.Items;
    }}
}}");
        }

        private void CreateGetByIdsQuery(Model model, string dir, string modelName)
        {
            var props = model.Properties.ToList();
            File.WriteAllText(Path.Combine(dir, $"Get{modelName}ByIds.cs"), $@"using .Core.Meteor;

namespace {_serviceName}.Operations.{modelName}.Queries
{{
    public class Get{modelName}ByIds : DbQueryByIds<{modelName}>
    {{
        public Get{modelName}ByIds() : base(""[{_serviceName}].[{modelName}]"")
        {{
        }}
    }}
}}");
        }

        private async Task CreateGetQueryPage(Model model, string dir, string modelName)
        {
            var props = model.Properties.ToList();
            await File.WriteAllTextAsync(Path.Combine(dir, $"Get{modelName}Page.cs"), $@"using .Core.Meteor;
using Meteor.Database.SqlDialect;
using {_serviceName}.Operations.{modelName}.Dto;

namespace {_serviceName}.Operations.{modelName}.Queries
{{
    public class Get{modelName}Page : DbQueryPage<{modelName}Dto>
    {{
        public Get{modelName}Page() : base(""[{_serviceName}].[{modelName}]"")
        {{
        }}
        {GenerateJoinSql(model, modelName)}
    }}
}}");
        }

        private string? GenerateJoinSql(Model model, string modelName)
        {
            var relatedModelProperties = model.Properties
                .Where(x => x.RelatedModelId.HasValue || x.Element?.Type == "lookup").ToList();
            if (!relatedModelProperties.Any())
                return null;

            var relatedModelById = new Dictionary<int, Model> {{model.Id, model}};
            var relatedServiceById = new Dictionary<int, Service> {{_service.Id, _service}};

            string GetTableName(int modelId) => relatedModelById[modelId].Name.Pascalize();

            string GetSchemaName(int modelId) =>
                relatedServiceById[relatedModelById[modelId]!.ServiceId]!.Name.Pascalize();

            string GetTableAliasName(int modelId, int index) => $"{GetTableName(modelId)}{index + 1}";

            string GetPropertyAliasName(ModelProperty property) =>
                $"{property.Name.Pascalize().TrimEnd('d').TrimEnd('I')}";

            string GetFullTableName(int modelId)
            {
                var tableName = GetTableName(modelId);
                var schemaName = GetSchemaName(modelId);
                return $"[{schemaName}].[{tableName}]";
            }

            foreach (var relatedModelProperty in relatedModelProperties)
            {
                var modelPropertyLookupModelId = SqServices.GetModel("Core", "ModelPropertyLookup")!.Id;
                relatedModelProperty.RelatedModelId ??= modelPropertyLookupModelId;
                if (relatedModelById.ContainsKey(relatedModelProperty.RelatedModelId!.Value))
                    continue;

                var s = relatedModelProperty.Element.Type == "lookup"
                    ? SqServices.GetService("Core")
                    : SqServices.Services.FirstOrDefault(x =>
                        x.Models.Any(y => y.Id == relatedModelProperty.RelatedModelId!.Value));
                var m = relatedModelProperty.Element.Type == "lookup"
                    ? SqServices.GetModel("Core", "ModelPropertyLookup")
                    : s?.Models.FirstOrDefault(x => x.Id == relatedModelProperty.RelatedModelId!.Value);
                if (m == null)
                    continue;

                relatedModelById.Add(relatedModelProperty.RelatedModelId!.Value, m);
                if (!relatedServiceById.ContainsKey(m.ServiceId))
                    relatedServiceById.Add(s!.Id, s);
            }

            return $@"


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {{
            {string.Join("\n\t\t\t", relatedModelProperties.Where(x => x.Element?.Type == "lookup").Select((x, i) => $"Parameters.Add(\"{GetPropertyAliasName(x)}\", SqSqServices.GetModelProperty(\"{_serviceName}\",\"{modelName}\",\"{x.Name}\")!.Id);"))}
            return SqlFactory!.Create().Select(""{GetFullTableName(model.Id)} {modelName}"", isForCount ? ""COUNT(*)"" : @""{"\n\t\t\t\t\t\t" + modelName}.*, {"\n\t\t\t\t\t\t" + string.Join(",\n\t\t\t\t\t\t", relatedModelProperties.Select((x, i) => $"{GetPropertyAliasName(x)}.Title AS {x.Name.Replace("Id", "").Pascalize()}Title"))}"")
{string.Join(Environment.NewLine, relatedModelProperties.Select((x, i) => $"                .LeftJoin(\"{GetFullTableName(x.RelatedModelId!.Value)} {GetPropertyAliasName(x)}\",  \"{modelName}.{x.Name.Pascalize()} = {GetPropertyAliasName(x)}.{(x.Element.Type == "lookup" ? $"Value AND {GetPropertyAliasName(x)}.ModelPropertyId=@{GetPropertyAliasName(x)}" : "Id")}  AND  {GetPropertyAliasName(x)}.IsDeleted=0\")"))};
        }}

        protected override string GetFieldName(string fieldName) =>
            $""[{modelName}].[{{fieldName}}]"";";
        }


        private void CreateGetQuery(Model model, string dir, string modelName)
        {
            var props = model.Properties.ToList();
            File.WriteAllText(Path.Combine(dir, $"Get{modelName}.cs"), $@"using .Core.Meteor;

namespace {_serviceName}.Operations.{modelName}.Queries
{{
    public class Get{modelName} : DbSelectAsync<{modelName}?>
    {{
        public Get{modelName}() : base(""[{_serviceName}].[{modelName}]"")
        {{
        }}
    }}
}}");
        }

        private void CreateDeleteCommand(Model model, string dir, string modelName)
        {
            File.WriteAllText(Path.Combine(dir, $"{modelName}Remove.cs"), $@"using .Core.Meteor;

namespace {_serviceName}.Operations.{modelName}.Commands
{{
    public class {modelName}Remove : DbDeleteAsync
    {{
        public {modelName}Remove() : base(""[{_serviceName}].[{modelName}]"")
        {{
        }}
    }}
}}");
        }

        private void CreateUpdateCommand(Model model, string dir, string modelName)
        {
            var props = model.Properties
                .Where(x => x.Updatable
                            && x.Name.ToLowerInvariant() != "isactive"
                            && x.Name.ToLowerInvariant() != "id")
                .ToList();
            File.WriteAllText(Path.Combine(dir, $"{modelName}Update.cs"), $@"using .Core.Meteor;
using {_serviceName}.Operations.{modelName}.Dto;

namespace {_serviceName}.Operations.{modelName}.Commands
{{
    public class {modelName}Update : DbUpdateAsync<{modelName}UpdateInDto>
    {{
        public {modelName}Update() : base(""[{_serviceName}].[{modelName}]"",
            @""{string.Join(",\n\t\t\t\t\t", props.Select(x => $"[{x.Name.Pascalize()}]=@{x.Name.Pascalize()}"))}"")
        {{
        }}
    }}
}}");
        }

        private void CreateAddCommand(Model model, string dir, string modelName)
        {
            var props = model.Properties
                .Where(x => x.Insertable
                            && x.Name.ToLowerInvariant() != "isactive"
                            && x.Name.ToLowerInvariant() != "id")
                .ToList();
            File.WriteAllText(Path.Combine(dir, $"{modelName}Add.cs"), $@"using System;
using .Core.Meteor;
using {_serviceName}.Operations.{modelName}.Dto;

namespace {_serviceName}.Operations.{modelName}.Commands
{{
    public class {modelName}Add : DbInsertAsync<{modelName}AddInDto>
    {{
        public {modelName}Add() : base(""[{_serviceName}].[{modelName}]"",
            @""{string.Join(",\n\t\t\t\t\t\t", props.Select(x => $"[{x.Name.Pascalize()}]"))}"",
            @""{string.Join(",\n\t\t\t\t\t\t", props.Select(x => "@" + x.Name.Pascalize()))}"")
        {{
        }}
    }}
}}

");
        }

        private void CreateModelFile(Model model, string modelFileName, string modelName)
        {
            File.WriteAllText(modelFileName, $@"using System;
using NodaTime;
using .Core.Meteor;
using .Core.Meteor.Dto;

namespace {_serviceName}.Operations.{modelName}
{{
    public class {modelName} : BaseModelDto, IDropDown
    {{
{string.Join(Environment.NewLine, model.Properties.Where(x => x.Name.ToLowerInvariant() != "id" && (x.Insertable || x.Updatable)).Select(x => "        " + CreatePropertyDefinition(x)))}
{(model.Properties.All(x => x.Name != "title") ? (model.Properties.Any(x => x.Name.ToLowerInvariant() == "name")) ? Environment.NewLine + "        public string Title => Name;" : "       public string Title {get; set;}" : "")}
    }}
}}
");
        }

        private async Task CreateDtoFile(Model model, string dtoFileName, string modelName)
        {
            var relatedModelProperties = model.Properties.Where(x => x.RelatedModelId.HasValue).ToList();

            await File.WriteAllTextAsync(dtoFileName, $@"namespace {_serviceName}.Operations.{modelName}.Dto
{{
    public class {modelName}Dto : {modelName}
    {{
{string.Join(Environment.NewLine, relatedModelProperties.Select(x =>
                $"        public string? {x.Name.Replace("Id", "").Pascalize()}Title {{ get; set; }}"))}
    }}
}}
");
        }

        private async Task CreateAddDtoFile(Model model, string dtoFileName, string modelName)
        {
            await File.WriteAllTextAsync(dtoFileName, $@"using NodaTime;
using .Core.Meteor.Dto;

namespace {_serviceName}.Operations.{modelName}.Dto
{{
    public class {modelName}AddInDto : DbInsertInDto
    {{
{string.Join(Environment.NewLine, model.Properties.Where(x => x.Name.ToLowerInvariant() != "id" && x.Name.ToLowerInvariant() != "isactive" && x.Insertable).Select(x => "        " + CreatePropertyDefinition(x)))}
{(model.Properties.All(x => x.Name != "title") && (model.Properties.Any(x => x.Name == "Name")) ? Environment.NewLine + "public string Title => Name;" : "")}
    }}
}}
");
        }

        private async Task CreateUpdateDtoFile(Model model, string dtoFileName, string modelName)
        {
            await File.WriteAllTextAsync(dtoFileName, $@"using NodaTime;
using .Core.Meteor.Dto;

namespace {_serviceName}.Operations.{modelName}.Dto
{{
    public class {modelName}UpdateInDto : DbUpdateInDto
    {{
{string.Join(Environment.NewLine, model.Properties.Where(x => x.Name.ToLowerInvariant() != "id" && x.Name.ToLowerInvariant() != "isactive" && x.Updatable).Select(x => "        " + CreatePropertyDefinition(x)))}
{(model.Properties.All(x => x.Name != "title") && (model.Properties.Any(x => x.Name == "Name")) ? Environment.NewLine + "public string Title => Name;" : "")}
    }}
}}
");
        }

        private static string CreatePropertyDefinition(ModelProperty property) =>
            $"public {GetCSharpType(property.Type)}{(property.IsRequired ? "" : "?")} {property.Name.Pascalize()} {{ get; set; }}";

        private static string GetCSharpType(string type) =>
            type switch
            {
                "image" => "ImageInfoJson",
                "bigint" => "long",
                "smallint" => "int",
                "tinyint" => "int",
                "dropdown" => "int",
                "icon" => "string",
                "ntext" => "string",
                "nchar" => "string",
                "nvarchar" => "string",
                "varchar" => "string",
                "datetime2" => "Instant",
                "datetime" => "DateTime",
                "instant" => "Instant",
                "date" => "Instant",
                "time" => "LocalTime",
                "bit" => "bool",
                _ => type
            };

        private void CreateProperties(string projectRoot)
        {
            var propDir = Path.Combine(projectRoot, "Properties");
            var fileName = Path.Combine(propDir, "launchSettings.json");
            Directory.CreateDirectory(propDir);
            var content = File.ReadAllText("./Template/launchSettings.json");
            File.WriteAllText(fileName, content
                .Replace("%NAMESPACE%", _serviceName)
                .Replace("%SERVICE_URL%", _service.BaseUrl)
                .Replace("%SERVICE_NAME%", _serviceName));
        }

        private void CreateAppSettings(string projectRoot)
        {
            File.Copy("./Template/appsettings.json", Path.Combine(projectRoot, "appsettings.json"), true);
            File.Copy("./Template/appsettings.Development.json",
                Path.Combine(projectRoot, "appsettings.Development.json"), true);
        }

        private void CreateStartupFile(string projectRoot)
        {
            var fileName = Path.Combine(projectRoot, "Startup.cs");
            var content = File.ReadAllText("./Template/Startup.cs");
            File.WriteAllText(fileName, content
                .Replace("%NAMESPACE%", _serviceName));
        }

        private void CreateProgramFile(string projectRoot)
        {
            var fileName = Path.Combine(projectRoot, "Program.cs");
            var content = File.ReadAllText("./Template/Program.cs");
            File.WriteAllText(fileName, content.Replace("%NAMESPACE%", _serviceName));
        }

        private void CreateProjectFile(string projectRoot)
        {
            var fileName = Path.Combine(projectRoot, _serviceName + ".csproj");
            File.Copy("./Template/Project.csproj", fileName, true);
        }
    }
}
