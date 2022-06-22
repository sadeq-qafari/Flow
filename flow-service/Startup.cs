using System.Collections.Generic;
using Dapper;
using Flow.Core;
using Flow.Core.Models;
using Flow.Operations.Form.Dtos;
using Flow.Operations.Lookup.Dtos;
using Meteor.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Saanaa.Core.AspNetCore;
using Saanaa.Core.AspNetCore.Extensions;
using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.SqlServer;

namespace Flow
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
            SqlMapper.AddTypeHandler(new SqlServerJsonTypeHandler<List<FormPropertyItem>?>());
            SqlMapper.AddTypeHandler(new SqlServerJsonTypeHandler<List<FormActionItem>?>());
            SqlMapper.AddTypeHandler(new SqlServerJsonTypeHandler<List<FormPropertySimpleDto>?>());
            SqlMapper.AddTypeHandler(new SqlServerJsonTypeHandler<List<FormActionSimpleDto>?>());
            SqlMapper.AddTypeHandler(new SqlServerJsonTypeHandler<List<FormPropertyModel>?>());
            SqlMapper.AddTypeHandler(new SqlServerJsonTypeHandler<List<LookupInfoItemDto>?>());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSaanaaCoreConfig();
            using var scope = app.ApplicationServices.CreateScope();
            var db = scope.ServiceProvider.GetService<LazyDbConnection>();
            SaanaaServices.Reload(db, ServiceConfig.Get("api_gateway_url")).Wait();
            SaanaaTenants.Reload(db).Wait();
            SaanaaForms.Reload(db).Wait();
        }
    }
}
