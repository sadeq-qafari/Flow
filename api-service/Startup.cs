using System.Linq;
using Meteor;
using Meteor.Database.SqlDialect.MsSql;
using Meteor.Operation;
using Meteor.Operation.Db;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Saanaa.Core.AspNetCore;
using Saanaa.Core.Meteor.SqlServer;

namespace Api
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
            services.AddControllers();
            services.AddCors(x => x.AddPolicy("dev",
                y =>
                {
                    y.SetIsOriginAllowed(o =>  ServiceConfig.TrustedUrls.Contains(o))
                        .AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                }));
            services.AddOcelot();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "ApiGateway", Version = "v1"}); });

            EnvVars.SetDefaultValue(EnvVarKeys.DbUri, ServiceConfig.Get("ServiceConfigConnectionString"));
            services.AddOperationFactory()
                .AddDbOperation<SqlServerDbConnectionFactory, MsSqlDialect>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiGateway v1"));
            }

            app.UseCors("dev");
            app.UseWebSockets();
            app.UseOcelot();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
