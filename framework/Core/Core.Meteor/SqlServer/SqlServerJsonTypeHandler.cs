using System.Data;
using Dapper;
using Meteor.Utils;
using Newtonsoft.Json;

namespace Core.Meteor.SqlServer
{
    public class SqlServerJsonTypeHandler<T> : SqlMapper.TypeHandler<T>
    {
        public override void SetValue(IDbDataParameter parameter, T value)
        {
            parameter.DbType = DbType.String;
            parameter.Value = JsonConvert.SerializeObject(value);
        }

        public override T Parse(object value)
        {
            return ((string)value).FromJson<T>();
        }
    }
}
