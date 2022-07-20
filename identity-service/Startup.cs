using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Dapper;
using Identity.Helper;
using IdentityServer4.Models;
using Meteor;
using Meteor.Database;
using Meteor.Database.SqlDialect.MsSql;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Core.AspNetCore;
using Core.AspNetCore.Extensions;
using Core.Meteor;
using Core.Meteor.SqlServer;

namespace Identity
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
            Console.WriteLine("We started running");
            services.AddSqCoreServices();
            services.AddHttpContextAccessor();

            EnvVars.SetDefaultValue(EnvVarKeys.DbUri, ServiceConfig.Get("ServiceConfigConnectionString"));
            services.AddOperationFactory()
                .AddDbOperation<SqlServerDbConnectionFactory, MsSqlDialect>();
            SqlMapper.AddTypeHandler(new SqlServerJsonTypeHandler<List<Secret>?>());
            SqlMapper.AddTypeHandler(new SqlServerJsonTypeHandler<Dictionary<string, string>?>());
            SqlMapper.AddTypeHandler(new SqlServerJsonTypeHandler<List<ClientClaim>?>());


            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                //options.User.AllowedUserNameCharacters ="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            var builder = services.AddIdentityServer(options =>
                {
                    options.IssuerUri = ServiceConfig.Get("base_url");
                    // options.PublicOrigin = AppConfig.Get("identity");
                    options.Events.RaiseErrorEvents = true;
                    options.Events.RaiseInformationEvents = true;
                    options.Events.RaiseFailureEvents = true;
                    options.Events.RaiseSuccessEvents = true;
                })
                .AddClientStore<ClientStore>()
                .AddResourceStore<ResourceStore>()
                .AddPersistedGrantStore<PersistedGrantStore>()
                .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
                .AddExtensionGrantValidator<VerificationCodeGrantValidator>()
                .AddExtensionGrantValidator<HashCodeGrantValidator>()
                .AddProfileService<ProfileService>();

            builder.AddSigningCredential(new X509Certificate2(
                Path.Combine(Environment.CurrentDirectory, "Certificate\\token_signing.pfx"), "qw12QW!@"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSqCoreConfig();
            app.UseIdentityServer();
            using var scope = app.ApplicationServices.CreateScope();
            var db = scope.ServiceProvider.GetService<LazyDbConnection>();
            SqServices.Reload(db, ServiceConfig.Get("api_gateway_url")).Wait();
            SqTenants.Reload(db).Wait();
        }
    }
}