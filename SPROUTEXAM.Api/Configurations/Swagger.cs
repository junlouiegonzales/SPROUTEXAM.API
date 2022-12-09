using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.Generation.Processors.Security;
using System.Linq;

namespace SPROUTEXAM.Api.Configurations
{
    public static class Swagger
    {
        internal static void RegisterSwagger(IServiceCollection services)
        {
            services.AddOpenApiDocument(c =>
            {
                c.DocumentName = "v1";
                c.Title = "SPROUTEXAM";
                c.Version = "v1";
                c.Description = "RESTFul Api for Sprout Exam";

                c.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Copy 'Bearer ' + valid JWT token into field"
                });

                c.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT"));
            });

        }

        internal static void ConfigureSwagger(IApplicationBuilder app)
        {
            app.UseOpenApi(settings =>
            {
                settings.PostProcess = (document, request) =>
                {
                    document.Info.Contact = new OpenApiContact
                    {
                        Name = "SPROUT EXAM",
                        Email = string.Empty,
                        Url = "http://yourwebsite.com"
                    };
                };
            });
            app.UseSwaggerUi3();
        }
    }
}