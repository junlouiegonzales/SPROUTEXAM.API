using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SPROUTEXAM.Infrastructure.Context;

namespace SPROUTEXAM.Api.Configurations
{
  public static class Security
  {
    internal static void RegisterSecurity(IServiceCollection services, IConfiguration configuration)
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

      // Identity
      services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
              .AddEntityFrameworkStores<SproutExamDbContext>();
    }

    internal static void ConfigureSecurity(IApplicationBuilder app)
    {
      app.UseCors("default");
      app.UseForwardedHeaders(new ForwardedHeadersOptions
      {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
      });

      // Identity
      app.UseAuthentication();
      app.UseIdentityServer();
      app.UseAuthorization();
    }
  }

  public class CorsOptions
  {
    //TODO: Improve validation to validate array of URI
    public List<string> AllowedOrigins { get; set; }
  }
}