using System.Collections.Generic;
using Core.AspNetCore;
using Core.AspNetCore.Extensions;
using Core.Meteor;
using Core.Meteor.SqlServer;
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
            services.AddSqCoreServices();
            SqlMapper.AddTypeHandler(new SqlServerJsonTypeHandler<List<FormPropertyItem>?>());
            SqlMapper.AddTypeHandler(new SqlServerJsonTypeHandler<List<FormActionItem>?>());
            SqlMapper.AddTypeHandler(new SqlServerJsonTypeHandler<List<FormPropertySimpleDto>?>());
            SqlMapper.AddTypeHandler(new SqlServerJsonTypeHandler<List<FormActionSimpleDto>?>());
            SqlMapper.AddTypeHandler(new SqlServerJsonTypeHandler<List<FormPropertyModel>?>());
            SqlMapper.AddTypeHandler(new SqlServerJsonTypeHandler<List<LookupInfoItemDto>?>());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSqCoreConfig();
            using var scope = app.ApplicationServices.CreateScope();
            var db = scope.ServiceProvider.GetService<LazyDbConnection>();
            SqServices.Reload(db, ServiceConfig.Get("api_gateway_url")).Wait();
            SqTenants.Reload(db).Wait();
            FlowForms.Reload(db).Wait();
        }
    }
}
