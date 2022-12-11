using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SPROUTEXAM.Domain.Entities;
using SPROUTEXAM.Infrastructure.Context;

namespace SPROUTEXAM.Api.Configurations
{
  public static class Security
  {
    internal static void RegisterSecurity(IServiceCollection services, IConfiguration configuration)
    {
      services.AddControllers();

      services.AddDefaultIdentity<IdentityUser>(options => 
      {
        options.SignIn.RequireConfirmedAccount = true;
      })
      .AddEntityFrameworkStores<SproutExamDbContext>();

      services.AddIdentityServer(options => {
          options.UserInteraction.LoginUrl = "/Login";
          options.UserInteraction.LogoutUrl = "/Logout";
          options.UserInteraction.ErrorUrl = "/Error";
      })
      .AddApiAuthorization<UserAccount, SproutExamDbContext>();

      services.AddAuthentication()
          .AddIdentityServerJwt();

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
      app.UseCors("default");
      app.UseForwardedHeaders(new ForwardedHeadersOptions
      {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
      });

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