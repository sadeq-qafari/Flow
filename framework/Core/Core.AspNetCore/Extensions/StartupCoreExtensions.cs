using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using Core.AspNetCore.Logger;
using Core.AspNetCore.Redis;
using Core.AspNetCore.Security;
using Core.Common.Cultures;
using Core.Meteor;
using Core.Meteor.SqlServer;
using Core.Meteor.Token;
using Dapper;
using IdentityServer4.AccessTokenValidation;
using Meteor;
using Meteor.AspCore.Utils;
using Meteor.Database.SqlDialect.MsSql;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;


namespace Core.AspNetCore.Extensions
{
    public static class StartupCoreExtensions
    {
        public static IServiceCollection AddSqCoreServices(this IServiceCollection services) =>
            services
                .AddResponseCompression()
                .AddSqRedis()
                .AddSqCors()
                .AddSqSwagger()
                //.AddSqSerilog()
                .AddSqAuthentication()
                .AddSqClients()
                //.AddSqEmail()
                .AddSqOperation()
                .AddSqControllers()
                .AddMeteorJsonConverters()
                .Services;

        public static IMvcBuilder AddSqControllers(this IServiceCollection services) =>
            services.AddControllers(x => x.Filters.Add<AssignUserInfoActionFilter>());

        public static IServiceCollection AddSqOperation(this IServiceCollection services)
        {
            EnvVars.SetDefaultValue(EnvVarKeys.DbUri, ServiceConfig.Get("ServiceConfigConnectionString"));
            return services.AddOperationFactory()
                .AddDbOperation<SqlServerDbConnectionFactory, MsSqlDialect>()
                .AddScopedOperationLogger<OperationLogger>();
        }

        public static IServiceCollection AddSqClients(this IServiceCollection services) =>
            services.AddSqTokenClient()
                .AddSqApiClient();
                // .AddSqIdentityClient();

        public static IApplicationBuilder UseSqCoreConfig(this IApplicationBuilder app) =>
            app
                .UseResponseCompression()
                .UseSqCors()
                .UseLocalization()
                .UseSwagger()
                .UseRouting()
                .UseStaticFiles()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => { endpoints.MapControllers(); });
                //.UseConsul();

        public static void LoadSqServiceConfigs(string serviceConfigConnectionString, string serviceName)
        {
            using var db = new SqlConnection(serviceConfigConnectionString);
            var serviceConfigs = db
                .Query<ServiceConfigItem>(
                    $"SELECT * FROM [Core].[ServiceConfig] WHERE ServiceName=N'common' OR ServiceName=N'{serviceName.ToLowerInvariant()}'");
            ServiceConfig.Add(serviceConfigs);

            var trustedUrls = db
                .Query<string>(
                    "SELECT [Url] FROM [Identity].[TenantUrl] TenantUrl WHERE IsDeleted=0 AND IsActive=1");
            ServiceConfig.SetTrustedUrls(trustedUrls);

            ServiceConfig.Add("ServiceConfigConnectionString", serviceConfigConnectionString);
            ServiceConfig.Add("ServiceName", serviceName);
        }

        // public static IServiceCollection AddSqEmail(this IServiceCollection services) =>
        //     services.Configure<EmailOptions>(options =>
        //     {
        //         options.Host = ServiceConfig.Get("email_server_smtp_host");
        //         options.Port = int.Parse(ServiceConfig.Get("email_server_smtp_port"));
        //     }).AddSingleton<EmailClient>();

        public static IServiceCollection AddSqPermission(this IServiceCollection services) =>
            services.AddSqSecurityService(x =>
            {
                x.IdentityApiUrl = ServiceConfig.Get("identity_listening_url");
                //x.MongoConnectionString = ServiceConfig.Get("mongo");
                x.RedisConnectionString = ServiceConfig.Get("redis");
            });

        // public static IServiceCollection AddSqIdentityClient(this IServiceCollection services) =>
        //     services.Configure<IdentityClientOptions>(options => { options.Url = ServiceConfig.Get("identity_listening_url"); })
        //         .AddHttpClient<IdentityClient>()
        //         .AddHttpMessageHandler<TokenDelegatingHandler>()
        //         .Services;

        public static IServiceCollection AddSqApiClient(this IServiceCollection services) =>
            services.AddHttpClient<ApiClient>()
                .AddHttpMessageHandler<TokenDelegatingHandler>()
                .ConfigureHttpMessageHandlerBuilder(builder =>
                {
                    builder.PrimaryHandler = new HttpClientHandler
                    {
                        ServerCertificateCustomValidationCallback = delegate { return true; }
                    };
                })
                .Services;


        public static IServiceCollection AddSqTokenClient(this IServiceCollection services)
        {
            services.Configure<TokenClientOptions>(options =>
            {
                options.Address = $"{ServiceConfig.Get("identity_listening_url")}/connect/token";
                options.ClientId = ServiceConfig.Get("backend_token_client_id");
                options.ClientSecret = ServiceConfig.Get("backend_token_client_secret");
            });
            services.AddHttpClient<TokenClient>();
            services.AddTransient<TokenDelegatingHandler>();
            return services;
        }

        public static IServiceCollection AddSqSerilog(this IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Serilog", LogEventLevel.Information)
                .Enrich.WithProperty("App", ServiceConfig.Get("ServiceName"))
                //.WriteTo.MongoDB(ServiceConfig.Get("mongo"), collectionName: "EventLog")
                .CreateLogger();

            return services;
        }

        public static IServiceCollection AddSqSwagger(this IServiceCollection services) =>
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo {Title = $"{ServiceConfig.Get("ServiceName")} API Documentation", Version = "v1"});
            });

        public static IServiceCollection AddSqCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("development", policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
                options.AddPolicy("production",
                    policy =>
                    {
                        policy
                            .SetIsOriginAllowedToAllowWildcardSubdomains()
                            .WithOrigins(ServiceConfig.TrustedUrls)
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

        public static IServiceCollection AddSqAuthentication(this IServiceCollection services)
        {
            var audiences = ServiceConfig.Get("audiences").Split(' ');
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters.ClockSkew = TimeSpan.FromMinutes(30);
                    options.Authority = ServiceConfig.Get("identity_listening_url");
                    options.RequireHttpsMetadata = !Convert.ToBoolean(ServiceConfig.Get("debug"));
                    options.BackchannelHttpHandler = new HttpClientHandler { ServerCertificateCustomValidationCallback = delegate { return true; } };
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudiences = audiences
                    };
                });

            return services
                .AddAuthorization(x =>
                {
                    foreach (var scope in audiences)
                        x.AddPolicy(scope, y => y.RequireClaim("scope", scope));
                })
                .AddSqPermission()
                .AddScoped<AuthorizationProvider>();
        }

        public static IServiceCollection AddSqRedis(this IServiceCollection services) =>
            services.AddSingleton(new RedisCache(ServiceConfig.Get("redis")));

        // public static IServiceCollection AddSqDbContext<TDb>(this IServiceCollection services) where TDb : DbContext =>
        //     services.AddDbContext<TDb>(options =>
        //         options.UseSqlServer(ServiceConfig.Get("db_connection_string"),
        //             sqlServerOptionsAction: sqlOptions =>
        //             {
        //                 //Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency
        //                 sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30),
        //                     errorNumbersToAdd: null);
        //             }));


        public static IApplicationBuilder UseLocalization(this IApplicationBuilder app)
        {
            var supportedCultures = new[]
            {
                new CultureInfo("fa-IR"),
                //new CultureInfo("en-US"),
            };

            return app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(CultureHelper.PersianCulture),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });
        }

        public static IApplicationBuilder UseSqCors(this IApplicationBuilder app) =>
            Convert.ToBoolean(ServiceConfig.Get("debug"))
                ? app.UseDeveloperExceptionPage().UseCors("development")
                : app.UseCors("production");
    }
}
