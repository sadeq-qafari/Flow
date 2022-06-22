using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Saanaa.Core.AspNetCore.Extensions;

namespace Cdn
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
            services.AddSaanaaCoreServices();
            // services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "CDN", Version = "v1"}); });
            // services.AddCors(x => x.AddPolicy("dev", y => y.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSaanaaCoreConfig();
            // if (env.IsDevelopment())
            // {
            //
            //     app.UseDeveloperExceptionPage();
            //     app.UseSwagger();
            //     app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CDN v1"));
            // }
            //
            // app.UseCors("dev");
            //
            // app.UseRouting();
            //
            // app.UseAuthorization();
            //
            // app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
