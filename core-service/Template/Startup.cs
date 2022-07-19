using Dapper;
using Meteor;
using Meteor.AspCore;
using Meteor.Database;
using Saanaa.Core.Meteor.Dto;
using Saanaa.Core.Meteor.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Saanaa.Core.AspNetCore;
using Saanaa.Core.AspNetCore.CoreExtensions;
using Meteor.Operation;
using Meteor.Database.SqlDialect.MsSql;
using Saanaa.Core.Meteor;

namespace %NAMESPACE%
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSaanaaCoreServices();

            EnvVars.SetDefaultValue(EnvVarKeys.DbUri, ServiceConfig.Get("ServiceConfigConnectionString"));
            services.AddOperationFactory()
                .AddDbOperation<SqlServerDbConnectionFactory, MsSqlDialect>();
            SqlMapper.AddTypeHandler(new SqlServerJsonTypeHandler<ImageInfoJson>());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSaanaaCoreConfig();
            using var scope = app.ApplicationServices.CreateScope();
            var db = scope.ServiceProvider.GetService<LazyDbConnection>();
            SaanaaServices.Reload(db, ServiceConfig.Get("api_gateway_url")).Wait();
        }

    }
}
