using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace SPROUTEXAM.Api.Configurations
{
    public static class AutoMapper
    {
        internal static void RegisterAutoMapper(IServiceCollection services)
        {
            //http://docs.automapper.org/en/stable/Inline-Mapping.html
            services.AddAutoMapper(
                configAction =>
                {
                    //configAction.ValidateInlineMaps = false;
                },
                typeof(Application.Response)
                );
                
        }
    }
}