using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor.Extensions;
using Dapper;
using Meteor.Database;
using Meteor.Database.MsSql;
using Meteor.Operation;

namespace Core.AspNetCore.Logger
{
    public class AddLog : OperationAsync<AddLogInDto, bool>
    {
        private const int MaxSeconds = 60;
        private const int MaxLogs = 1000;

        private static DateTime _lastInsertAt = DateTime.MinValue;
        private static readonly List<AddLogInDto> _logs = new();

        protected override Task LogAsync() =>
            Task.CompletedTask;

        protected override async Task ExecutionAsync()
        {
            Input.CreatedAt = DateTime.Now;
            _logs.Add(Input);
            if ((DateTime.UtcNow - _lastInsertAt).TotalSeconds < MaxSeconds && _logs.Count < MaxLogs)
                return;

            var db = new LazyDbConnection(new MsSqlDbConnectionFactory(ServiceConfig.Get("log_db_connection_string")));
            var dt =_logs.AsDataTable("dbo.udt_logs", x => x);
            const string sqlText = @"
INSERT FlowLog.dbo.Logs (
  Service, TableName, UserId, EntityId, TenantId, Type, Message, MessageTemplate, Level, Exception, Properties, CreatedAt
) SELECT * FROM @Items";
            var @params = new DynamicParameters();
            @params.Add("Items", dt.AsTableValuedParameter("dbo.udt_logs"));
            Output = await db.ExecuteAsync(sqlText, @params) > 0;
            _lastInsertAt = DateTime.UtcNow;
            _logs.Clear();
        }
    }
}
