using System;
using System.Data;
using Dapper;
using NodaTime;

namespace Core.Meteor.SqlServer
{
    public class SqlServerInstantTypeHandler : SqlMapper.TypeHandler<Instant>
    {
        public override Instant Parse(object value)
        {
            return Instant.FromDateTimeUtc(new DateTime(((DateTime) value).Ticks, DateTimeKind.Utc));
        }

        public override void SetValue(IDbDataParameter parameter, Instant value)
        {
            parameter.DbType = DbType.DateTime2;
            parameter.Value = value.ToDateTimeUtc();
        }
    }
}
