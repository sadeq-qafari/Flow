using System.Collections.Generic;
using Dapper;
using Meteor.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Saanaa.Core.AspNetCore;
using Saanaa.Core.AspNetCore.Extensions;
using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;
using Saanaa.Core.Meteor.SqlServer;

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
            services.AddSaanaaCoreServices();
            SqlMapper.AddTypeHandler(new SqlServerJsonTypeHandler<ImageInfoJson>());
            SqlMapper.AddTypeHandler(new SqlServerJsonTypeHandler<Dictionary<string,object>?>());
            // SqlMapper.AddTypeHandler(new SqlServerJsonTypeHandler<List<OrganizationDetailItem?>?>());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSaanaaCoreConfig();
            using var scope = app.ApplicationServices.CreateScope();
            var db = scope.ServiceProvider.GetService<LazyDbConnection>();
            SaanaaServices.Reload(db, ServiceConfig.Get("api_gateway_url")).Wait();
            SaanaaTenants.Reload(db).Wait();
        }

    }
}
