using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SPROUTEXAM.Api.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace SPROUTEXAM.Api.Configurations
{
    public static class Mvc
    {
        internal static IMvcBuilder RegisterMvc (IServiceCollection services) 
        {
            return services.AddMvc (options => {
                options.Filters.Add (typeof (CustomExceptionFilterAttribute));
                options.Filters.Add (typeof (ActionValidationFilterAttribute));
            }).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0)
			  .AddNewtonsoftJson(options =>
			  {
				  options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
				  options.SerializerSettings.Converters.Add(new StringEnumConverter());
				  options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
			  });
        }

        internal static void ConfigureMvc (IApplicationBuilder app) 
        {
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints =>
            { 
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}