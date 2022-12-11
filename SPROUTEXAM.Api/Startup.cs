using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SPROUTEXAM.Infrastructure.Context;
using static SPROUTEXAM.Api.Configurations.AutoMapper;
using static SPROUTEXAM.Api.Configurations.Db;
using static SPROUTEXAM.Api.Configurations.FluentValidation;
using static SPROUTEXAM.Api.Configurations.MediatR;
using static SPROUTEXAM.Api.Configurations.Mvc;
using static SPROUTEXAM.Api.Configurations.Security;
using static SPROUTEXAM.Api.Configurations.Services;
using static SPROUTEXAM.Api.Configurations.Swagger;
namespace SPROUTEXAM.Api
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

      RegisterEntityFramework(services, Configuration);
      RegisterSwagger(services);
      RegisterMediatR(services);
      RegisterAutoMapper(services);
      RegisterServices(services, Configuration);

      RegisterSecurity(services, Configuration);
      IMvcBuilder mvcBuilder = RegisterMvc(services);
      AddFluentValidation(mvcBuilder);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SproutExamDbContext context)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        SeedDatabase(context);
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
      }

      ConfigureDatabaseMigrations(context);
      ConfigureSecurity(app);
      ConfigureSwagger(app);
      ConfigureMvc(app);
    }
  }
}
