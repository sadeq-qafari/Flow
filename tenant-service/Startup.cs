using System.Collections.Generic;
using Dapper;
using Meteor.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Core.AspNetCore;
using Core.AspNetCore.Extensions;
using Core.Meteor;
using Core.Meteor.Dto;
using Core.Meteor.SqlServer;

namespace Tenant
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
            services.AddSqCoreServices();
            SqlMapper.AddTypeHandler(new SqlServerJsonTypeHandler<ImageInfoJson>());
            SqlMapper.AddTypeHandler(new SqlServerJsonTypeHandler<Dictionary<string,object>?>());
            // SqlMapper.AddTypeHandler(new SqlServerJsonTypeHandler<List<OrganizationDetailItem?>?>());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSqCoreConfig();
            using var scope = app.ApplicationServices.CreateScope();
            var db = scope.ServiceProvider.GetService<LazyDbConnection>();
            SqServices.Reload(db, ServiceConfig.Get("api_gateway_url")).Wait();
            SqTenants.Reload(db).Wait();
        }

    }
}
