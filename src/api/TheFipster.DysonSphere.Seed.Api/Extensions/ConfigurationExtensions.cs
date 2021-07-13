using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TheFipster.DysonSphere.Seed.Api.Abstractions;
using TheFipster.DysonSphere.Seed.Api.Services;

namespace TheFipster.DysonSphere.Seed.Api.Extensions
{
    public static class ConfigurationExtensions
    {
        private const string CorsConfigName = "SeedApiCors";

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Seed.Api", Version = "v1" });
            });

            return services;
        }

        public static IServiceCollection AddCrossOriginResourceSharing(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: CorsConfigName,
                    builder => builder
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                );
            });

            return services;
        }

        public static IApplicationBuilder UseCrossOriginResourceSharing(this IApplicationBuilder app)
        {
            app.UseCors(CorsConfigName);

            return app;
        }

        public static IApplicationBuilder UseApiDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Seed.Api v1"));

            return app;
        }

        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IFlatClusterLoader, FlatClusterLoader>();
            services.AddScoped<IClusterLoader, ClusterLoader>();

            return services;
        }
    }
}
