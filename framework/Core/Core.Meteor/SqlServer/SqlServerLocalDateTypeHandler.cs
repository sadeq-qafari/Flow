using System;
using System.Data;
using Dapper;
using NodaTime;

namespace Core.Meteor.SqlServer
{
    public class SqlServerLocalDateTypeHandler : SqlMapper.TypeHandler<LocalDate?>
    {
        public override LocalDate? Parse(object? value)
        {
            return value != null ? LocalDate.FromDateTime((DateTime) value) : null;
        }

        public override void SetValue(IDbDataParameter parameter, LocalDate? value)
        {
            parameter.DbType = DbType.Date;
            parameter.Value = value?.ToDateTimeUnspecified();
        }
    }
}
