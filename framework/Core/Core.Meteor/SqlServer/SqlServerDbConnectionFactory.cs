using System.Data.Common;
using System.Threading.Tasks;
using Core.Meteor.Dto;
using Meteor.Database;
using Microsoft.Data.SqlClient;

namespace Core.Meteor.SqlServer
{
    public class SqlServerDbConnectionFactory : DbConnectionFactory
    {
        public SqlServerDbConnectionFactory(string connectionString = null)
            : base(connectionString)
        {
            Dapper.SqlMapper.AddTypeHandler(new SqlServerLocalDateTypeHandler());
            Dapper.SqlMapper.AddTypeHandler(new SqlServerLocalTimeTypeHandler());
            Dapper.SqlMapper.AddTypeHandler(new SqlServerInstantTypeHandler());
            Dapper.SqlMapper.AddTypeHandler(new SqlServerJsonTypeHandler<ImageInfoJson>());
            Dapper.SqlMapper.AddTypeHandler(new GeographyTypeHandler());
        }

        public override async Task<DbConnection> OpenNewConnectionAsync()
        {
            var conn = new SqlConnection(ConnectionString);
            await conn.OpenAsync().ConfigureAwait(false);
            return conn;
        }
    }
}
