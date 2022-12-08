using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SPROUTEXAM.Api.Configurations
{
    public static class CORS
    {
        internal static void AddCorsPolicy(IServiceCollection services, IConfiguration configuration)
        {
            var corsOptions = new CorsOptions();
            configuration.GetSection("Cors").Bind(corsOptions);

            services.AddCors(options =>
            {
                options.AddPolicy("default", policy => policy
                    .WithOrigins(corsOptions.AllowedOrigins.ToArray())
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    );
            });
            services.AddControllers();
        }
    }

    public class CorsOptions
    {
        //TODO: Improve validation to validate array of URI
        public List<string> AllowedOrigins { get; set; }
    }
}