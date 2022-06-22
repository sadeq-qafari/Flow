using Meteor.AspCore.Utils;
using Meteor.Database;
using Meteor.Database.MsSql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Saanaa.Core.AspNetCore;
using Saanaa.Core.AspNetCore.Extensions;
using Saanaa.Core.Meteor;
using Saanaa.Providers.Notification.SignalR;

namespace Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddResponseCompression()
                .AddSaanaaRedis()
                .AddCors(options =>
                {
                    options.AddPolicy("development", policy =>
                    {
                        policy.WithOrigins("http://localhost:4200")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    });

                    options.AddPolicy("production",
                        policy =>
                        {
                            policy
                                .SetIsOriginAllowedToAllowWildcardSubdomains()
                                .WithOrigins(ServiceConfig.TrustedUrls)
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials();
                        });
                })
                .AddSaanaaSwagger()
                .AddSaanaaAuthentication()
                .AddSaanaaTokenClient()
                .AddSaanaaApiClient()
                .AddSaanaaEmail()
                .AddSaanaaOperation()
                .AddSaanaaControllers()
                .AddMeteorJsonConverters();

            // EnvVars.SetDefaultValue(EnvVarKeys.DbUri, ServiceConfig.Get("ServiceConfigConnectionString"));
            // services.AddOperationFactory()
            //     .AddDbOperation<SqlServerDbConnectionFactory, MsSqlDialect>()
            //     .AddScopedOperationLogger<OperationLogger>();

            services.AddGenericHub(options => options.IdentityServiceUrl = ServiceConfig.Get("identity_listening_url"));

            SaanaaServices
                .Reload(new LazyDbConnection(new MsSqlDbConnectionFactory(ServiceConfig.Get("ServiceConfigConnectionString"))),
                    ServiceConfig.Get("api_gateway_url")).Wait();
            // var service = new ProjectBuilder( "Core","D:/GeneratedProjects");
            // service.Build().Wait();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
                .UseResponseCompression()
                .UseSaanaaCors()
                .UseLocalization()
                .UseSwagger()
                .UseRouting()
                .UseStaticFiles()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapHub<GenericHub>("/ws/notification");
                });

            using var scope = app.ApplicationServices.CreateScope();
            var db = scope.ServiceProvider.GetService<LazyDbConnection>();
            SaanaaServices.Reload(db, ServiceConfig.Get("api_gateway_url")).Wait();
            SaanaaTenants.Reload(db).Wait();
            // var apiClient = scope.ServiceProvider.GetService<ApiClient>();
            // var res = apiClient.GetAsync<dynamic>("Tenant", "Person").Result;
        }
    }
}
