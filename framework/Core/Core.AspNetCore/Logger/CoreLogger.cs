using System;
using System.Collections.Generic;
using System.Data;
using Meteor;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Sinks.MSSqlServer;

namespace Core.AspNetCore.Logger
{
    public static class CoreLogger
    {
        public static Serilog.Core.Logger CreateCoreLogger()
        {
            // Configure System Log
            var columnOpts = new ColumnOptions();
            columnOpts.Store.Remove(StandardColumn.Properties);
            columnOpts.Store.Add(StandardColumn.LogEvent);
            columnOpts.Store.Remove(StandardColumn.TimeStamp);
            columnOpts.LogEvent.ColumnName = "Properties";
            columnOpts.LogEvent.ExcludeAdditionalProperties = true;
            columnOpts.LogEvent.ExcludeStandardColumns = true;
            columnOpts.AdditionalColumns = new List<SqlColumn>
            {
                new SqlColumn("Service", SqlDbType.NVarChar),
                new SqlColumn("TableName", SqlDbType.NVarChar),
                new SqlColumn("UserId", SqlDbType.Int),
                new SqlColumn("EntityId", SqlDbType.BigInt),
                new SqlColumn("TenantId", SqlDbType.Int)
            };

            return new LoggerConfiguration()
                .MinimumLevel.Warning()
                .MinimumLevel.Override("System", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
                .Enrich.WithProperty("Service", EnvVars.Get("SERVICE_NAME"))
                .Enrich.WithExceptionDetails()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("logs/log-.txt",
                    rollingInterval: RollingInterval.Day,
                    fileSizeLimitBytes: 512 * 1024 * 1024,
                    retainedFileCountLimit: 1,
                    outputTemplate:
                    "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}")
                .WriteTo.MSSqlServer(
                    restrictedToMinimumLevel: Enum.Parse<LogEventLevel>(ServiceConfig.Get("log_level"), true),
                    connectionString: ServiceConfig.Get("log_db_connection_string"),
                    sinkOptions: new MSSqlServerSinkOptions {TableName = "Logs"},
                    columnOptions: columnOpts
                )
                .CreateLogger();
        }
    }
}
