using System;
using System.Data;
using Dapper;
using NodaTime;

namespace Core.Meteor.SqlServer
{
    public class SqlServerLocalTimeTypeHandler : SqlMapper.TypeHandler<LocalTime?>
    {
        public override LocalTime? Parse(object? value)
        {
            return value != null ? LocalTime.FromTicksSinceMidnight(((TimeSpan) value).Ticks) : null;
        }

        public override void SetValue(IDbDataParameter parameter, LocalTime? value)
        {
            parameter.DbType = DbType.Time;
            parameter.Value = value.HasValue ? null : TimeSpan.FromTicks(value!.Value.TickOfDay);
        }
    }
}
