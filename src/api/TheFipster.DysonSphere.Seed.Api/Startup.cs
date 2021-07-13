using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheFipster.DysonSphere.Seed.Api.Extensions;

namespace TheFipster.DysonSphere.Seed.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCrossOriginResourceSharing();
            services.AddControllers();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddSwagger();
            services.AddMemoryCache();
            services.AddDomain();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseApiDocumentation();
            }

            app.UseCrossOriginResourceSharing();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
