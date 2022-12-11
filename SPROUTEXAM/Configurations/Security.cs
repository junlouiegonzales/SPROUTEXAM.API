using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SPROUTEXAM.Domain.Entities;
using SPROUTEXAM.Infrastructure.Context;

namespace SPROUTEXAM.Configurations
{
  public static class Security
  {
    internal static void RegisterSecurity(IServiceCollection services, IConfiguration configuration)
    {
      services.AddDefaultIdentity<UserAccount>(options => options.SignIn.RequireConfirmedAccount = true)
          .AddEntityFrameworkStores<SproutExamDbContext>();

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
    }

    internal static void ConfigureSecurity(IApplicationBuilder app)
    {
      app.UseAuthentication();
      app.UseAuthorization();
    }
  }

  public class CorsOptions
  {
    //TODO: Improve validation to validate array of URI
    public List<string> AllowedOrigins { get; set; }
  }
}