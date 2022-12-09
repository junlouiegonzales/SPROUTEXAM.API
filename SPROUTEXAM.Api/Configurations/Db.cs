using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SPROUTEXAM.Infrastructure.Context;

namespace SPROUTEXAM.Api.Configurations
{
    public static class Db
    {
        internal static void RegisterEntityFramework(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");

            services.AddDbContext<SproutExamDbContext>(opts =>
            {
                opts.UseSqlServer(connectionString);
            });
        }

        internal static void ConfigureDatabaseMigrations(SproutExamDbContext context)
        {
            //Check if there are any pending migrations
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }

        internal static void SeedDatabase(SproutExamDbContext context)
        {
            // Seed Database
        }
    }
}